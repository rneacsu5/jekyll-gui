using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace jekyll_gui.Forms
{
	public partial class TemplateDialog : Form
	{

		public class JekyllTemplate
		{
			public string Name;
			public string SourceURL;
			public string DemoURL;
			public string SourceZipURL
			{
				get
				{
					if (SourceURL.Replace("github.com", "api.github.com/repos").Equals(SourceURL)) return "";
					return SourceURL.Replace("github.com", "api.github.com/repos") + "/zipball";
				}
			}

			public JekyllTemplate() : this(null, null, null) { }

			public JekyllTemplate(string name, string sourceURL, string demoURL)
			{
				Name = name;
				SourceURL = sourceURL;
				DemoURL = demoURL;
			}

			public override string ToString()
			{
				return Name;
			}
		}

		private JekyllTemplate selectedTemplate = null;

		private string outputDir;

		public TemplateDialog(string outputDir)
		{
			InitializeComponent();
			this.outputDir = outputDir;
			DialogResult = DialogResult.Cancel;
		}

		private void refreshTemplatesList()
		{
			templatesListBox.Items.Clear();
			templatesListBox.Items.Add(new JekyllTemplate("Downloading list...", null, null));
			templatesListBox.Enabled = false;

			displayTemplate(-1);

			WebClient listDL = new WebClient();
			listDL.DownloadStringCompleted += listDL_DownloadStringCompleted;
			listDL.DownloadStringAsync(new Uri(@"https://raw.githubusercontent.com/wiki/jekyll/jekyll/Themes.md"));
		}

		private void listDL_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error != null) {
				Tools.DisplayError("Could not download list.", e.Error);
				return;
			}
			populateTemplates(e.Result);
		}

		private void populateTemplates(string markdown)
		{
			templatesListBox.Items.Clear();
			displayTemplate(-1);

			if (string.IsNullOrEmpty(markdown)) return;

			markdown = Regex.Replace(markdown, @"- +[^\[\n]*(?=\(\[)", "");
			foreach (Match m in Regex.Matches(markdown, @"\* +(.*) +\(\[source\]\s*\(([^\)]+)\)(?:.*\[demo\]\s*\()?([^\)\s]*)\)?\)")) {
				templatesListBox.Items.Add(new JekyllTemplate(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value));
			}

			templatesListBox.Enabled = true;
			templatesListBox.SelectedIndex = 0;
		}

		private void displayTemplate(int index)
		{
			if (index < 0 ||
				index >= templatesListBox.Items.Count ||
				templatesListBox.Items[index] == null ||
				!(templatesListBox.Items[index] is JekyllTemplate) ||
				string.IsNullOrEmpty(((JekyllTemplate) templatesListBox.Items[index]).SourceURL)) {
				templatePanel.Enabled = templatePanel.Visible = false;
				return;
			}

			selectedTemplate = (JekyllTemplate) templatesListBox.Items[index];
			templateNameLb.Text = selectedTemplate.Name;

			if (!string.IsNullOrEmpty(selectedTemplate.SourceZipURL)) {
				submitBtn.Enabled = true;
			}
			else {
				submitBtn.Enabled = false;
			}

			if (!string.IsNullOrEmpty(selectedTemplate.DemoURL)) {
				viewInBrowserBtn.Enabled = true;
				demoBrowser.DocumentText = "<html><head><meta http-equiv=\"refresh\" content=\"0; url=" + selectedTemplate.DemoURL + "\" /></head><body><h4>Loading...</h4></body></html>";
			}
			else {
				viewInBrowserBtn.Enabled = false;
				demoBrowser.DocumentText = "<html><body><h4>This template does not provide a demo site.</h4></body></html>";
			}

			templatePanel.Enabled = templatePanel.Visible = true;
		}

		private bool applyTemplate()
		{
			if (selectedTemplate == null || string.IsNullOrEmpty(selectedTemplate.SourceURL)) return false;

			string tempDir = outputDir + @"\.tmp";
			string zip = tempDir + @"\source.zip";

			if (!Tools.DirectoryDelete(tempDir)) return false;

			try {
				Directory.CreateDirectory(tempDir).Attributes = FileAttributes.Directory | FileAttributes.Hidden;
			}
			catch (Exception ex) {
				Tools.DisplayError("Could not create temp directory.", ex);
				return false;
			}

			// Download zip
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += (object s1, DoWorkEventArgs e1) => {
				WebClient sourceDL = new WebClient();
				sourceDL.Headers[HttpRequestHeader.UserAgent] = "Jekyll GUI";
				sourceDL.DownloadProgressChanged += (object s2, DownloadProgressChangedEventArgs e2) => {
					bw.ReportProgress(e2.ProgressPercentage);
					if (bw.CancellationPending) {
						sourceDL.CancelAsync();
						e1.Cancel = true;
					}
				};
				sourceDL.DownloadFileAsync(new Uri(selectedTemplate.SourceZipURL), zip);
				while (sourceDL.IsBusy) Thread.Sleep(100);

				if (!File.Exists(zip)) throw new WebException("File not found");
				FileInfo info = new FileInfo(zip);
				if (info.Length == 0) throw new WebException("Nothing downloaded");
			};

			ProgressForm form = new ProgressForm(bw, "Downloading source...", true);
			switch (form.ShowDialog()) {
				case DialogResult.OK:
					break;
				case DialogResult.Abort:
					Tools.DisplayError("Could not download source.", form.Error);
					return false;
				case DialogResult.Cancel:
					return false;
				default:
					return false;
			}

			// Extract zip
			if (!Tools.ExtractArchive(zip, tempDir)) return false;

			// Move contents
			string[] dirs = Directory.GetDirectories(tempDir);
			if (dirs.Length != 1) return false;
			if (!Tools.DirectoryMove(dirs[0], outputDir)) return false;

			// Clean
			if (!Tools.DirectoryDelete(tempDir)) return false;

			return true;
		}


		private void TemplateDialog_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.jekyll_icon;
			displayTemplate(-1);
			refreshTemplatesList();
			Size = Properties.Settings.Default.TemplateDialogSize;
		}

		private void refreshTemplatesBtn_Click(object sender, EventArgs e)
		{
			refreshTemplatesList();
		}

		private void templatesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			displayTemplate(templatesListBox.SelectedIndex);
		}

		private void submitBtn_Click(object sender, EventArgs e)
		{
			if (!applyTemplate()) return;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void viewInBrowserBtn_Click(object sender, EventArgs e)
		{
			try {
				Process.Start(selectedTemplate.DemoURL);
			}
			catch (Exception) { }
		}

		private void viewSourceBtn_Click(object sender, EventArgs e)
		{
			try {
				Process.Start(selectedTemplate.SourceURL);
			}
			catch (Exception) { }
		}

		private void TemplateDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.TemplateDialogSize = Size;
			Properties.Settings.Default.Save();
		}
	}
}
