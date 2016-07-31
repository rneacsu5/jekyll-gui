using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace jekyll_gui.Forms
{
	public partial class ProgressForm : Form
	{

		private BackgroundWorker bw;
		/// <summary>
		/// Error threw by BackgrownWorker or null
		/// </summary>
		public Exception Error = null;

		/// <summary>
		/// Progress form that runs a BackgroundWorkder and displays its progress
		/// </summary>
		/// <param name="bw">The background worker to run</param>
		/// <param name="text">Text to be displayed on the form</param>
		/// <param name="displayProgressBar">Wether to show a ProgressBar or not</param>
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

			// Set background worker events
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
				// If the progress is at 0, the progress bar's style will stay at marquee
				if (e1.ProgressPercentage == 0) return;
				taskProgressBar.Style = ProgressBarStyle.Continuous;
				taskProgressBar.Value = e1.ProgressPercentage;
			};

			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;

			// Run the worker async
			bw.RunWorkerAsync();
		}

		private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// If the user wants to close the form, fist cancel the task and wait for it to finish
			if (bw.IsBusy) {
				e.Cancel = true;
				bw.CancelAsync();
			}
		}
	}
}
