using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace jekyll_gui.Forms
{
	public partial class MainForm : Form
	{

		private string projectPath = "";
		private ConsoleTask serveTask = new ConsoleTask();
		private ConsoleTask newTask = new ConsoleTask();
		private ConsoleTask buildTask = new ConsoleTask();

		public MainForm()
		{
			InitializeComponent();

			ConsoleTask.SetForm(this);
			ConsoleTask.SetConsole(consoleTextBox);
			serveTask.AddTaskCompleteEventHandler(serve_TaskComplete);
			updateJekyllTasks();
		}


		/// <summary>
		/// Updates all the ConsoleTasks with new IP and port
		/// </summary>
		private void updateJekyllTasks()
		{
			JekyllEnv.IPAddres = Tools.GetLocalIPAddress();
			JekyllEnv.PortNumber = (uint) portNumericBox.Value;
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

			// Update UI
			hostLb.Text = "http:\\\\" + Tools.GetLocalIPAddress() + ":" + portNumericBox.Value;
			toggleServerBtn.Text = "Stop Server";
			toggleServerBtn.ForeColor = System.Drawing.Color.DarkRed;
			toggleServerBtn.Enabled = true;
			portPanel.Visible = portPanel.Enabled = false;
			serverStatusPanel.Enabled = serverStatusPanel.Visible = true;
			cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = rebuildMenuItem.Enabled = false;
			cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = rebuildMenuItem.ToolTipText = "Stop server first";
		}

		private void stopServer()
		{
			toggleServerBtn.Enabled = false;
			serveTask.StopTask();

			// Update UI
			toggleServerBtn.Text = "Start Server";
			toggleServerBtn.ForeColor = System.Drawing.Color.DarkGreen;
			toggleServerBtn.Enabled = true;
			serverStatusPanel.Enabled = serverStatusPanel.Visible = false;
			portPanel.Visible = portPanel.Enabled = true;
			cleanMenuItem.Enabled = buildMenuItem.Enabled = exportMenuItem.Enabled = rebuildMenuItem.Enabled = true;
			cleanMenuItem.ToolTipText = buildMenuItem.ToolTipText = exportMenuItem.ToolTipText = rebuildMenuItem.ToolTipText = null;
			if (!projectPanel.Visible) exportMenuItem.Enabled = false;
		}

		private void toggleServer()
		{
			if (serveTask.IsRunning)
				stopServer();
			else
				startServer();
		}

		/// <summary>
		/// Shows the user a browse dialog
		/// </summary>
		/// <param name="path">The selected path, if successful</param>
		/// <param name="empty">If true, warn the user if the selected folder is non empty</param>
		/// <returns>True if successfull, false if not</returns>
		private bool browseFolder(out string path, bool empty)
		{
			path = null;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				path = folderBrowserDialog.SelectedPath;
				try {
					if (empty && Directory.GetFileSystemEntries(path).Length != 0) {
						DialogResult result = MessageBox.Show("Selected folder is not empty. Proceed anyways?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
						if (result == DialogResult.Cancel) return false;
						if (result == DialogResult.No) return browseFolder(out path, empty);
					}
					return true;
				}
				catch (Exception ex) {
					Tools.DisplayError("Could not browse folder.", ex);
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Create a new demo project (runs jekyll new)
		/// </summary>
		private void createNewProject()
		{
			openProject(true);
			newTask.RunTaskSync();
		}

		/// <summary>
		/// Opens a project and updates view, calling browseFolder() first
		/// </summary>
		/// <param name="empty">This gets passed to browseFolder()</param>
		/// <returns>True if successfull, false if not</returns>
		private bool openProject(bool empty) { return openProject(null, empty); }

		/// <summary>
		/// Opens a project and updates views
		/// </summary>
		/// <param name="path">Path to project location or null to call browseFolder() first</param>
		/// <param name="empty">This gets passed to browseFolder() if path was null</param>
		/// <returns>True if successfull, false if not</returns>
		private bool openProject(string path, bool empty)
		{
			if (string.IsNullOrEmpty(path) && !browseFolder(out path, empty)) return false;
			closeProject();

			// Update UI
			projectNameLb.Text = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
			projectPathLb.Text = projectPath = path;
			projectPanel.Visible = projectPanel.Enabled = projectMenu.Enabled = exportMenuItem.Enabled = true;
			foreach (ToolStripItem m in projectMenu.DropDownItems) {
				if (m is ToolStripMenuItem) m.Enabled = true;
			}
			updateJekyllTasks();
			return true;
		}

		/// <summary>
		/// Exports the site, building it if needed. browseFolder() is called to get export folder
		/// </summary>
		private void exportProject()
		{
			string buildDir = projectPath + @"\_site";
			string outDir;

			// Build site if needed
			if (!Directory.Exists(buildDir)) {
				buildTask.RunTaskSync();
			}

			// Browse for export dir
			if (!browseFolder(out outDir, true)) return;

			consoleTextBox.Clear();
			consoleTextBox.AppendText("Copying files..." + Environment.NewLine);

			if (Tools.DirectoryCopy(buildDir, outDir)) {
				consoleTextBox.AppendText("Successfully exported site to " + outDir + Environment.NewLine);
			}
			else {
				consoleTextBox.AppendText("Aborted." + Environment.NewLine);
			}
		}

		/// <summary>
		/// Cleans generated filse (deletes _site and .sass-cache folders)
		/// </summary>
		private void cleanProject()
		{
			string[] paths = { @"\_site", @"\.sass-cache" };
			foreach (string path in paths) {
				if (!Tools.DirectoryDelete(projectPath + path)) return;
			}

			consoleTextBox.Clear();
		}

		private void closeProject()
		{
			stopServer();

			// Update UI
			projectPanel.Visible = projectPanel.Enabled = projectMenu.Enabled = exportMenuItem.Enabled = false;
			foreach (ToolStripItem m in projectMenu.DropDownItems) {
				if (m is ToolStripMenuItem) m.Enabled = false;
			}
			consoleTextBox.Text = "";
			projectNameLb.Text = projectPathLb.Text = projectPath = "";
		}


		#region Event Handlers
		private void MainForm_Load(object sender, EventArgs e)
		{
			// Set Icon
			Icon = Properties.Resources.jekyll_icon;
			
			// Check for environment
			if (!JekyllEnv.InstallJekyllEnvironment()) Close();

			closeProject();

			// Restore state
			Size = Properties.Settings.Default.MainFormSize;
			string path = Properties.Settings.Default.LastOpenPath;
			if (!string.IsNullOrEmpty(path) && Directory.Exists(path)) openProject(path, false);
		}


		private void defaultProjectMenuItem_Click(object sender, EventArgs e)
		{
			createNewProject();
		}

		private void emptyProjectMenuItem_Click(object sender, EventArgs e)
		{
			openProject(true);
		}

		private void fromTemplatMenuItem_Click(object sender, EventArgs e)
		{
			if (!openProject(true)) return;
			TemplateDialog d = new TemplateDialog(projectPath);
			if (d.ShowDialog() != DialogResult.OK) closeProject();
		}


		private void openMenuItem_Click(object sender, EventArgs e)
		{
			openProject(false);
		}

		private void exportMenuItem_Click(object sender, EventArgs e)
		{
			exportProject();
		}

		private void closeMenuItem_Click(object sender, EventArgs e)
		{
			closeProject();
		}


		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void toggleServerMenuItem_Click(object sender, EventArgs e)
		{
			toggleServerBtn.PerformClick();
		}

		private void buildMenuItem_Click(object sender, EventArgs e)
		{
			buildTask.RunTaskSync();
		}

		private void rebuildMenuItem_Click(object sender, EventArgs e)
		{
			// Rebuild is clean + build
			cleanMenuItem_Click(sender, e);
			buildMenuItem_Click(sender, e);
		}

		private void cleanMenuItem_Click(object sender, EventArgs e)
		{
			cleanProject();
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
			// Easter Egg
			MessageBox.Show("This product was possible thanks to the power of Nexus. For more info and awesomeness, a website will appear.", "Nexus Power", MessageBoxButtons.OK);
			Process.Start(@"http://topor.io");
		}

		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			Form f = new AboutForm();
			f.ShowDialog();
		}


		private void consoleMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			copyConsoleMenuItem.Visible = (consoleTextBox.SelectionLength == 0) ? false : true;
			// If the console is empty there is no need for menu strip
			e.Cancel = (consoleTextBox.TextLength == 0) ? true : false;
		}

		private void copyConsoleMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(consoleTextBox.SelectedText);
		}

		private void copyAllConsoleMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(consoleTextBox.Text);
		}

		private void clearConsoleMenuItem_Click(object sender, EventArgs e)
		{
			consoleTextBox.Clear();
		}


		private void projectPathLb_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(projectPath)) {
				Process.Start(projectPath);
			}
			else {
				Tools.DisplayError("Path not found. Please make sure the project exists.");
			}
		}

		private void hostLb_Click(object sender, EventArgs e)
		{
			Process.Start(hostLb.Text);
		}

		private void toggleServerBtn_Click(object sender, EventArgs e)
		{
			toggleServer();
		}

		private void portNumericBox_ValueChanged(object sender, EventArgs e)
		{
			// Update port
			JekyllEnv.PortNumber = (uint) portNumericBox.Value;
		}

		private void portNumericBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				startServer();
			}
		}

		private void serve_TaskComplete(object sender, RunWorkerCompletedEventArgs e)
		{
			stopServer();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Save state
			Properties.Settings.Default.MainFormSize = Size;
			Properties.Settings.Default.LastOpenPath = projectPath;
			Properties.Settings.Default.Save();
		}
		#endregion
	}
}
