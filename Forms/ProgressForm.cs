using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace jekyll_gui
{
	public partial class ProgressForm : Form
	{

		private BackgroundWorker bw;
		public Exception Error = null;


		public ProgressForm(BackgroundWorker bw, string text, bool displayProgressBar)
		{
			InitializeComponent();
			this.bw = bw;
			progressTextLb.Text = text;
			taskProgressBar.Visible = displayProgressBar;
		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{
			// Set Icon
			Icon = Properties.Resources.jekyll_icon;

			bw.RunWorkerCompleted += (object s1, RunWorkerCompletedEventArgs e1) => {
				if (e1.Cancelled) {
					DialogResult = DialogResult.Cancel;
				}
				else if (e1.Error != null) {
					Error = e1.Error;
					DialogResult = DialogResult.Abort;
				}
				else {
					DialogResult = DialogResult.OK;
				}
				Close();
			};

			bw.ProgressChanged += (object s1, ProgressChangedEventArgs e1) => {
				taskProgressBar.Value = e1.ProgressPercentage;
			};

			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.RunWorkerAsync();
		}

		private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bw.IsBusy) {
				e.Cancel = true;
				bw.CancelAsync();
			}
		}
	}
}
