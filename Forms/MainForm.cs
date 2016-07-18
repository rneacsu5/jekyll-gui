using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using SevenZip;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace jekyll_gui
{

	public partial class MainForm : Form
	{
		enum ServerState
		{
			RUNNING,
			STOPPED
		}

		private ServerState serverState = ServerState.STOPPED;
		private int portNumber = 4000;
		private string projectPath = "";
		private ConsoleTask serveTask = new ConsoleTask();
		private ConsoleTask newTask = new ConsoleTask();
		private ConsoleTask buildTask = new ConsoleTask();

		public MainForm()
		{
			InitializeComponent();

			ConsoleTask.SetForm(this);
			ConsoleTask.SetConsole(consoleText);
			updateJekyllEnv();
		}


		private void updateJekyllEnv()
		{
			JekyllEnv.IPAddres = getLocalIPAddress();
			JekyllEnv.PortNumber = portNumber;
			JekyllEnv.WorkingDir = projectPath;
			JekyllEnv.SetJekyllConsoleTask(serveTask, JekyllEnv.JekyllCommand.SERVE_SITE);
			JekyllEnv.SetJekyllConsoleTask(newTask, JekyllEnv.JekyllCommand.CREATE_SITE);
			JekyllEnv.SetJekyllConsoleTask(buildTask, JekyllEnv.JekyllCommand.BUILD_SITE);
		}

		private void startServer()
		{
			if (newTask.IsRunning) return;
			JekyllEnv.SetJekyllConsoleTask(serveTask, JekyllEnv.JekyllCommand.SERVE_SITE);
			serveTask.RunTaskAsync();
			serverState = ServerState.RUNNING;

			toggleServerBtn.Text = "Stop Server";
			toggleServerBtn.ForeColor = System.Drawing.Color.DarkRed;
			toggleServerBtn.Enabled = true;
			serverStatusPanel.Enabled = serverStatusPanel.Visible = true;
			cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = false;
			cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = "Stop server first";
		}

		private void stopServer()
		{
			toggleServerBtn.Enabled = false;
			serveTask.StopTask();

			toggleServerBtn.Text = "Start Server";
			toggleServerBtn.ForeColor = System.Drawing.Color.DarkGreen;
			toggleServerBtn.Enabled = true;
			serverStatusPanel.Enabled = serverStatusPanel.Visible = false;
			cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = true;
			cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = null;
			if (!projectPanel.Visible) exportMenuItem.Enabled = false;

			serverState = ServerState.STOPPED;
		}

		private void openProject(string path)
		{
			closeProject();
			projectNameLb.Text = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
			projectPathLb.Text = projectPath = path;
			projectPanel.Visible = projectPanel.Enabled = projectMenu.Enabled = exportMenuItem.Enabled = true;
			hostLb.Text = "http:\\\\" + getLocalIPAddress() + ":" + portNumber;
			updateJekyllEnv();
		}

		private void closeProject()
		{
			stopServer();
			projectPanel.Visible = projectPanel.Enabled = projectMenu.Enabled = exportMenuItem.Enabled = false;
			consoleText.Text = "";
			projectNameLb.Text = projectPathLb.Text = projectPath = "";
		}

		private static string getLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList) {
				if (ip.AddressFamily == AddressFamily.InterNetwork) {
					return ip.ToString();
				}
			}
			return "localhost";
		}


		/* Events handlers */

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Set Icon
			Icon = Properties.Resources.jekyll_icon;

			// Check for environment
			if (!File.Exists(CONSTANTS.RUBY_PATH) || !File.Exists(CONSTANTS.JEKYLL_PATH)) {
				// Need to install the Environment
				if (!File.Exists(CONSTANTS.ARCHIVE_PATH)) {
					MessageBox.Show("Could not locate \"" + CONSTANTS.ARCHIVE_PATH + "\". Please reinstall this app and try again.", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
					return;
				}

				// Create Async task
				BackgroundWorker bw = new BackgroundWorker();
				bw.DoWork += (object s1, DoWorkEventArgs e1) => {
					SevenZipBase.SetLibraryPath(CONSTANTS.SEVEN_ZIP_LIB);
					SevenZipExtractor sze = new SevenZipExtractor(CONSTANTS.ARCHIVE_PATH);
					sze.Extracting += (object s2, ProgressEventArgs e2) => {
						bw.ReportProgress(e2.PercentDone * 10);
						if (bw.CancellationPending) {
							e2.Cancel = true;
							e1.Cancel = true;
						}
					};

					sze.ExtractArchive(CONSTANTS.ENV_FOLDER);
				};

				ProgressForm form = new ProgressForm(bw, "Extracting files, please wait...", true);
				DialogResult result = form.ShowDialog();

				if (result == DialogResult.Abort) {
					MessageBox.Show("An error occured when extracting \"" + CONSTANTS.ARCHIVE_PATH + "\"\n" + form.Error.ToString(), "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (result != DialogResult.OK) {
					Close();
					return;
				}
			}

			closeProject();
		}


		private void newProjectMenuItem_Click(object sender, EventArgs e)
		{
			if (projectFolderDialog.ShowDialog() == DialogResult.OK) {
				string path = projectFolderDialog.SelectedPath;
				if (Directory.GetFileSystemEntries(path).Length != 0) {
					DialogResult result = MessageBox.Show("Selected folder is not empty. Proceed anyways?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (result == DialogResult.Cancel) {
						return;
					}
					if (result == DialogResult.No) {
						newProjectMenuItem_Click(sender, e);
						return;
					}
				}

				// Run "jekyll new" in that folder
				openProject(path);
				newTask.RunTaskSync();
			}
		}

		private void openMenuItem_Click(object sender, EventArgs e)
		{
			if (projectFolderDialog.ShowDialog() == DialogResult.OK) {
				openProject(projectFolderDialog.SelectedPath);
			}
		}

		private void exportMenuItem_Click(object sender, EventArgs e)
		{
			string SourcePath = projectPath + @"\_site";
			if (!Directory.Exists(SourcePath)) {
				buildTask.RunTaskSync();
			}

			FolderBrowserDialog browser = new FolderBrowserDialog();
			browser.Description = "Select destination folder";
			if (browser.ShowDialog() == DialogResult.OK) {
				string DestinationPath = browser.SelectedPath;
				if (Directory.GetFileSystemEntries(DestinationPath).Length != 0) {
					DialogResult result = MessageBox.Show("Selected folder is not empty. Proceed anyways?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (result == DialogResult.Cancel) {
						return;
					}
					if (result == DialogResult.No) {
						exportMenuItem_Click(sender, e);
						return;
					}
				}

				consoleText.Clear();
				consoleText.AppendText("Copying files...");
				consoleText.AppendText(Environment.NewLine);

				// Code inspired from http://stackoverflow.com/a/3822913/3680746

				// Create all of the directories
				foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories)) {
					Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
					consoleText.AppendText("Creating " + dirPath.Replace(SourcePath, DestinationPath));
					consoleText.AppendText(Environment.NewLine);
				}

				// Copy all the files & replaces any files with the same name
				foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories)) {
					consoleText.AppendText("Copying " + newPath);
					File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
					consoleText.AppendText(Environment.NewLine);
				}


				consoleText.AppendText("Successfully exported site to " + DestinationPath);
				consoleText.AppendText(Environment.NewLine);
			}
		}

		private void moreThemesMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"https://github.com/jekyll/jekyll/wiki/Themes");
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void buildMenuItem_Click(object sender, EventArgs e)
		{
			if (!buildTask.IsRunning) buildTask.RunTaskSync();
		}

		private void cleanMenuItem_Click(object sender, EventArgs e)
		{
			string[] paths = { @"\_site", @"\.sass-cache" };
			foreach (string path in paths) {
				if (Directory.Exists(projectPath + path)) {
					Directory.Delete(projectPath + path, true);
				}
			}

			consoleText.Clear();
		}

		private void closeMenuItem_Click(object sender, EventArgs e)
		{
			closeProject();
		}


		private void jekyllMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"https://jekyllrb.com/docs/home/");
		}

		private void kramdownMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"http://kramdown.gettalong.org/syntax.html");
		}

		private void webdevMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"http://www.w3schools.com/");
		}

		private void toporSeparator_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This product was possible thanks to the power of Nexus. For more info and awesomeness, a website will appear.", "Nexus Power", MessageBoxButtons.OK);
			Process.Start(@"http://topor.io");
		}

		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			Form f = new AboutForm();
			f.ShowDialog();
		}



		private void projectPathLb_Click(object sender, EventArgs e)
		{
			Process.Start(projectPathLb.Text);
		}

		private void hostLb_Click(object sender, EventArgs e)
		{
			Process.Start(hostLb.Text);
		}

		private void toggleServerBtn_Click(object sender, EventArgs e)
		{
			switch (serverState) {
				case ServerState.RUNNING:
					stopServer();
					break;
				case ServerState.STOPPED:
					startServer();
					break;
			}
		}

	}

}
