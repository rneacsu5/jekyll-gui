using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace jekyll_gui {

	public partial class MainForm : Form {

		

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			// Set Icon
			Icon = Properties.Resources.jekyll_icon;

			// Check for environment
			if (!File.Exists(CONSTANTS.RUBY_PATH) || !File.Exists(CONSTANTS.JEKYLL_PATH)) {
				// Need to install the Environment
				if (!File.Exists(CONSTANTS.ARCHIVE_PATH)) {
					MessageBox.Show("Could not locate \"" + CONSTANTS.ARCHIVE_PATH + "\". Please reinstall this app and try again.", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
				}

				InstallBinariesForm form = new InstallBinariesForm();
				DialogResult result = form.ShowDialog();

				if (result != DialogResult.OK) {
					Close();
				}
			}

			//setProjectPanel(false);
			
		}

		/// <summary>
		/// Enables or disables the main panel. Visibility is also changed
		/// </summary>
		/// <param name="enable">true = enable it; false = disable and hide it</param>
		private void setProjectPanel(bool enable) {
			projectPanel.Visible = enable;
			projectPanel.Enabled = enable;
		}

		private void exitMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void toolStripSeparator2_Click(object sender, EventArgs e) {
			MessageBox.Show("This product was possible thanks to the power of Nexus. For more info and awesomeness, a website will appear.", "Nexus Power", MessageBoxButtons.OK);
			Process.Start(@"http://topor.io");
		}

		private void projectPathLb_Click(object sender, EventArgs e) {
			Process.Start(projectPathLb.Text);
		}

		private void moreThemesMenuItem_Click(object sender, EventArgs e) {
			Process.Start(@"https://github.com/jekyll/jekyll/wiki/Themes");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			Form f = new AboutForm();
			f.ShowDialog();
		}
	}

	static class CONSTANTS {
		public static string ROOT_FOLDER = "Data";
		public static string ENV_FOLDER = ROOT_FOLDER + @"\ruby-jekyll-env";
		public static string BIN_FOLDER = ENV_FOLDER + @"\bin";
		public static string RUBY_PATH = BIN_FOLDER + @"\ruby.exe";
		public static string JEKYLL_PATH = BIN_FOLDER + @"\jekyll";
		public static string ARCHIVE_PATH = ROOT_FOLDER + @"\ruby-jekyll-env.zip";
	}
}
