using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using Ionic.Zip;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace jekyll_gui
{

	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();

			newBW = new BackgroundWorker();
			newBW.DoWork += (s1, e1) => {
				Process p = JekyllEnv.CreateJekyllProcess("new . --force", projectPath);
				p.Start();
				p.WaitForExit();
			};

			buildBW = new BackgroundWorker();
			buildBW.DoWork += (s1, e1) => {
				Process p = JekyllEnv.CreateJekyllProcess("build", projectPath);

				buildBW.ReportProgress(1, "Building...");

				p.OutputDataReceived += (object s2, DataReceivedEventArgs e2) => {
					buildBW.ReportProgress(0, e2.Data);
				};
				p.ErrorDataReceived += (object s2, DataReceivedEventArgs e2) => {
					buildBW.ReportProgress(0, e2.Data);
				};

				p.Start();
				p.BeginOutputReadLine();
				p.BeginErrorReadLine();

				p.WaitForExit();

				p.CancelOutputRead();
				p.CancelErrorRead();
			};
			buildBW.ProgressChanged += (object s1, ProgressChangedEventArgs e1) => {
				if (e1.ProgressPercentage == 1) consoleText.Clear();
				if (e1.UserState != null) {
					consoleText.AppendText((string) e1.UserState);
					consoleText.AppendText(Environment.NewLine);
				}
			};
			buildBW.RunWorkerCompleted += (object s1, RunWorkerCompletedEventArgs e1) => {
				consoleText.AppendText("Build done.");
			};

			buildBW.WorkerReportsProgress = true;

			serveBW = new BackgroundWorker();
			serveBW.DoWork += (s1, e1) => {
				Process p = JekyllEnv.CreateJekyllProcess("serve -H " + ipAddress + " -P " + portNumber, projectPathLb.Text);

				serveBW.ReportProgress(1, "Starting server...");

				p.OutputDataReceived += (object s2, DataReceivedEventArgs e2) => {
					serveBW.ReportProgress(0, e2.Data);
				};
				p.ErrorDataReceived += (object s2, DataReceivedEventArgs e2) => {
					serveBW.ReportProgress(0, e2.Data);
				};

				p.Start();
				p.BeginOutputReadLine();
				p.BeginErrorReadLine();

				while (!serveBW.CancellationPending && !p.HasExited) {
					Thread.Sleep(500);
				}

				p.CancelOutputRead();
				p.CancelErrorRead();
				if (!p.HasExited)
					p.Kill();
			};
			serveBW.ProgressChanged += (object s1, ProgressChangedEventArgs e1) => {
				if (e1.ProgressPercentage == 1) consoleText.Clear();
				if (e1.UserState != null) {
					consoleText.AppendText((string) e1.UserState);
					consoleText.AppendText(Environment.NewLine);
				}
			};
			serveBW.RunWorkerCompleted += (object s1, RunWorkerCompletedEventArgs e1) => {
				if (closeFormPending) {
					closeFormPending = false;
					Close();
				}
				else
					setServerState(ServerState.STOPPED);
			};

			serveBW.WorkerReportsProgress = true;
			serveBW.WorkerSupportsCancellation = true;
		}


		enum ServerState
		{
			RUNNING,
			STOPPED
		}

		private ServerState serverState = ServerState.STOPPED;
		private int portNumber = 4000;
		private String projectPath = "";
		private String ipAddress = "localhost";
		private BackgroundWorker serveBW;
		private BackgroundWorker newBW;
		private BackgroundWorker buildBW;
		private bool closeFormPending = false;


		private void setProjectPanel(bool enable)
		{
			projectPanel.Visible = projectPanel.Enabled = projectMenu.Enabled = exportMenuItem.Enabled = enable;
		}

		private void setServerState(ServerState s)
		{
			serverState = s;
			switch (s) {
				case ServerState.RUNNING:
					toggleServerBtn.Text = "Stop Server";
					toggleServerBtn.ForeColor = System.Drawing.Color.DarkRed;
					toggleServerBtn.Enabled = true;
					serverStatusPanel.Enabled = serverStatusPanel.Visible = true;
					cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = false;
					cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = "Stop server first";
					break;
				case ServerState.STOPPED:
					toggleServerBtn.Text = "Start Server";
					toggleServerBtn.ForeColor = System.Drawing.Color.DarkGreen;
					toggleServerBtn.Enabled = true;
					serverStatusPanel.Enabled = serverStatusPanel.Visible = false;
					cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = true;
					cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = null;
					if (!projectPanel.Visible) exportMenuItem.Enabled = false;
					break;
			}
		}

		private static string getLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList) {
				if (ip.AddressFamily == AddressFamily.InterNetwork) {
					return ip.ToString();
				}
			}
			throw new Exception("Local IP Address Not Found!");
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
				}

				BackgroundWorker bw = new BackgroundWorker();
				ZipFile zf = new ZipFile(CONSTANTS.ARCHIVE_PATH);
				// Set Async task
				bw.DoWork += (object s1, DoWorkEventArgs e1) => {

					zf.ExtractProgress += (object s2, ExtractProgressEventArgs e2) => {
						if (e2.EventType == ZipProgressEventType.Extracting_AfterExtractEntry) {
							bw.ReportProgress((int) ((e2.EntriesExtracted / (double) e2.EntriesTotal) * 1000));
							if (bw.CancellationPending) {
								e2.Cancel = true;
								e1.Cancel = true;
							}
						}
					};

					zf.ExtractAll(CONSTANTS.ENV_FOLDER, ExtractExistingFileAction.OverwriteSilently);
				};

				ProgressForm form = new ProgressForm(bw, "Extracting files, please wait...", true);
				DialogResult result = form.ShowDialog();

				if (result == DialogResult.Abort) {
					MessageBox.Show("An error occured when extracting \"" + CONSTANTS.ARCHIVE_PATH + "\"\n" + form.Error.ToString(), "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (result != DialogResult.OK) {
					Close();
				}
			}

			setServerState(ServerState.STOPPED);
			setProjectPanel(false);

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


				if (serverState == ServerState.RUNNING) {
					toggleServerBtn.PerformClick();
				}

				projectNameLb.Text = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
				projectPathLb.Text = projectPath = path;

				setServerState(ServerState.STOPPED);
				consoleText.Text = "";

				// Run "jekyll new" in that folder
				ProgressForm form = new ProgressForm(newBW, "Creating new project...", false);
				form.ShowDialog();

				setProjectPanel(true);

			}
		}

		private void openMenuItem_Click(object sender, EventArgs e)
		{
			if (projectFolderDialog.ShowDialog() == DialogResult.OK) {
				string path = projectFolderDialog.SelectedPath;

				if (serverState == ServerState.RUNNING) {
					toggleServerBtn.PerformClick();
				}

				projectNameLb.Text = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
				projectPathLb.Text = projectPath = path;
				setServerState(ServerState.STOPPED);
				consoleText.Text = "";
				setProjectPanel(true);
			}
		}

		private void exportMenuItem_Click(object sender, EventArgs e)
		{
			string SourcePath = projectPath + @"\_site";
			if (!Directory.Exists(SourcePath)) {
				MessageBox.Show("Please build the website first.", "Jekyll GUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			FolderBrowserDialog browser = new FolderBrowserDialog();
			browser.Description = "Select destination folder";
			if (browser.ShowDialog() == DialogResult.OK) {
				string DestinationPath = browser.SelectedPath;

				consoleText.Clear();
				consoleText.AppendText("Copying files...");
				consoleText.AppendText(Environment.NewLine);

				// Code from http://stackoverflow.com/a/3822913/3680746

				// Create all of the directories
				foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
					Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

				// Copy all the files & replaces any files with the same name
				foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
					File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);

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
			if (!buildBW.IsBusy) buildBW.RunWorkerAsync();
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
			if (serverState == ServerState.RUNNING) {
				toggleServerBtn.PerformClick();
			}
			setProjectPanel(false);
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
					toggleServerBtn.Enabled = false;
					serveBW.CancelAsync();
					break;
				case ServerState.STOPPED:
					ipAddress = getLocalIPAddress();
					portNumber = 4000;

					hostLb.Text = "http:\\\\" + ipAddress + ":" + portNumber;
					setServerState(ServerState.RUNNING);

					serveBW.RunWorkerAsync();
					break;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (serveBW.IsBusy && !closeFormPending) {
				closeFormPending = true;
				toggleServerBtn.PerformClick();
			}
			if (closeFormPending) e.Cancel = true;
		}
	}

	static class CONSTANTS
	{
		public static string ROOT_FOLDER = "Data";
		public static string ENV_FOLDER = ROOT_FOLDER + @"\ruby-jekyll-env";
		public static string BIN_FOLDER = ENV_FOLDER + @"\bin";
		public static string RUBY_PATH = BIN_FOLDER + @"\ruby.exe";
		public static string JEKYLL_PATH = BIN_FOLDER + @"\jekyll";
		public static string ARCHIVE_PATH = ROOT_FOLDER + @"\ruby-jekyll-env.zip";
	}

}
