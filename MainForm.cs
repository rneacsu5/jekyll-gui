using System;
using System.Windows.Forms;
using System.IO;

namespace jekyll_gui {

	public partial class MainForm : Form {

		

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			// Set Icon
			Icon = Properties.Resources.jekyll;
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
