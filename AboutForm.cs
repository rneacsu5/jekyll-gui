using System.Windows.Forms;
using System.Diagnostics;

namespace jekyll_gui {
	public partial class AboutForm : Form {
		public AboutForm() {
			InitializeComponent();
		}

		private void AboutForm_Load(object sender, System.EventArgs e) {
			versionLb.Text = "Version " + Application.ProductVersion;
		}

		private void websiteLb_Click(object sender, System.EventArgs e) {
			Process.Start(@"http://cnnb.ro");
		}

		private void author1Lb_Click(object sender, System.EventArgs e) {
			Process.Start(@"https://www.facebook.com/neacsu.razvan.75");
		}

		private void author2Lb_Click(object sender, System.EventArgs e) {

		}
	}
}
