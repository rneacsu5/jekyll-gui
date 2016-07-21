using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using SevenZip;

namespace jekyll_gui
{
	static class Tools
	{

		public static void DisplayError(string info) { DisplayError(info, null); }

		public static void DisplayError(string info, Exception e)
		{
			if (e != null)
				MessageBox.Show(info + Environment.NewLine + "Error message: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show(info, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList) {
				if (ip.AddressFamily == AddressFamily.InterNetwork) {
					return ip.ToString();
				}
			}
			return "localhost";
		}

		public static bool ExtractArchive(string archivePath, string destPath)
		{
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += (object s1, DoWorkEventArgs e1) => {
				SevenZipBase.SetLibraryPath(CONSTANTS.SEVEN_ZIP_LIB);
				SevenZipExtractor sze = new SevenZipExtractor(archivePath);
				sze.Extracting += (object s2, ProgressEventArgs e2) => {
					bw.ReportProgress(e2.PercentDone);
					if (bw.CancellationPending) {
						e2.Cancel = true;
						e1.Cancel = true;
					}
				};

				sze.ExtractArchive(destPath);
			};

			Forms.ProgressForm form = new Forms.ProgressForm(bw, "Extracting files, please wait...", true);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.Abort) {
				DisplayError("An error occured when extracting \"" + archivePath + "\"", form.Error);
			}
			if (result != DialogResult.OK) {
				return false;
			}

			return true;
		}

		public static bool DirectoryCopy(string sourcePath, string destPath)
		{
			if (!Directory.Exists(sourcePath)) return false;

			try {
				Directory.CreateDirectory(destPath);
				foreach (string fileA in Directory.GetFiles(sourcePath)) {
					string fileB = fileA.Replace(sourcePath, destPath);
					if (File.Exists(fileB)) File.Delete(fileB);
					File.Copy(fileA, fileB);
				}
				foreach (string dirA in Directory.GetDirectories(sourcePath)) {
					string dirB = dirA.Replace(sourcePath, destPath);
					if (!DirectoryCopy(dirA, dirB)) return false;
				}
				return true;
			}
			catch (Exception e) { DisplayError("IO error occured while copying directory.", e); return false; }
		}

		public static bool DirectoryMove(string sourcePath, string destPath)
		{
			if (!Directory.Exists(sourcePath)) return false;
			try {
				if (!Directory.Exists(destPath)) {
					Directory.Move(sourcePath, destPath);
					return true;
				}
				foreach (string fileA in Directory.GetFiles(sourcePath)) {
					string fileB = fileA.Replace(sourcePath, destPath);
					if (File.Exists(fileB)) File.Delete(fileB);
					File.Move(fileA, fileB);
				}
				foreach (string dirA in Directory.GetDirectories(sourcePath)) {
					string dirB = dirA.Replace(sourcePath, destPath);
					if (!DirectoryMove(dirA, dirB)) return false;
				}
				return true;
			}
			catch (Exception e) { DisplayError("IO error occured while copying directory.", e); return false; }
		}

		public static bool DirectoryDelete(string dirPath)
		{
			try {
				if (Directory.Exists(dirPath))
					Directory.Delete(dirPath, true);
				return true;
			}
			catch (Exception ex) {
				DisplayError("Could not delete \"" + dirPath + "\".", ex);
				return false;
			}
		}

	}
}
