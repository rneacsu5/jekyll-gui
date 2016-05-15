using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ionic.Zip;

namespace jekyll_gui {
	public partial class InstallBinariesForm : Form {

		BackgroundWorker bw = new BackgroundWorker();
		ZipFile zf = new ZipFile(CONSTANTS.ARCHIVE_PATH);

		public InstallBinariesForm() {
			InitializeComponent();
		}

		private void InstallBinariesForm_Load(object sender, EventArgs e) {
			// Set Icon
			Icon = Properties.Resources.jekyll;

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

			bw.RunWorkerCompleted += (object s1, RunWorkerCompletedEventArgs e1) => {
				if (e1.Cancelled) {
					DialogResult = DialogResult.Cancel;
				}
				else if (e1.Error != null) {
					MessageBox.Show("An error occured when extracting \"" + CONSTANTS.ARCHIVE_PATH + "\"\n" + e1.Error.ToString(), "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					DialogResult = DialogResult.Abort;
				}
				else {
					DialogResult = DialogResult.OK;
				}
				Close();
			};

			bw.ProgressChanged += (object s1, ProgressChangedEventArgs e1) => {
				installProgress.Value = e1.ProgressPercentage;
			};

			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.RunWorkerAsync();
		}

		private void InstallBinariesForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (bw.IsBusy) {
				e.Cancel = true;
				bw.CancelAsync();
			}
		}
	}
}
