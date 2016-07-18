using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System;

namespace jekyll_gui
{

	public class ConsoleTask
	{
		private static Form form = null;
		private static TextBox console = null;
		private static bool closePending = false;
		private static AutoResetEvent allClosed = new AutoResetEvent(false);
		private static int runningTasks = 0;
		private static Mutex mux = new Mutex();

		private Process proc = new Process();
		public string CommandInfo;
		private BackgroundWorker bw = new BackgroundWorker();
		private AutoResetEvent isDone = new AutoResetEvent(false);
		private bool muteOutput = false;


		public ConsoleTask() : this(null, null, null, null) { }

		public ConsoleTask(string command, string args, string workingDir, string commandInfo)
		{
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.CreateNoWindow = true;

			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.RedirectStandardInput = true;
			proc.StartInfo.RedirectStandardError = true;

			proc.OutputDataReceived += proc_OutputDataReceived;
			proc.ErrorDataReceived += proc_OutputDataReceived;

			SetCommandLine(command, args, workingDir);
			CommandInfo = commandInfo;

			bw.DoWork += bw_DoWork;
			bw.ProgressChanged += bw_ProgressChanged;
			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
		}


		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			mux.WaitOne();
			runningTasks++;
			allClosed.Reset();
			mux.ReleaseMutex();

			isDone.Reset();

			proc.Start();
			proc.BeginOutputReadLine();
			proc.BeginErrorReadLine();

			while (!proc.HasExited && !bw.CancellationPending && !closePending) Thread.Sleep(100);
			if (!proc.HasExited) proc.Kill();

			proc.CancelOutputRead();
			proc.CancelErrorRead();

			bw.ReportProgress(0, "Task finished.");

			isDone.Set();

			mux.WaitOne();
			runningTasks--;
			if (runningTasks == 0) allClosed.Set();
			mux.ReleaseMutex();
		}

		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState != null) writeToConsole((string) e.UserState);
		}

		private void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			bw.ReportProgress(0, e.Data);
		}

		private void writeToConsole(string line) 
		{
			if (!muteOutput && console != null && !console.IsDisposed && line != null) {
				console.AppendText(line);
				console.AppendText(Environment.NewLine);
			}
		}

		private void clearConsole() 
		{
			if (console != null && !console.IsDisposed) {
				console.Clear();
			}
		}

		public void SetCommandLine(string command, string args, string workingDir)
		{
			proc.StartInfo.FileName = command;
			proc.StartInfo.Arguments = args;
			proc.StartInfo.WorkingDirectory = workingDir;
		}

		public void RunTaskAsync()
		{
			if (!bw.IsBusy) {
				muteOutput = false;
				clearConsole();
				writeToConsole(CommandInfo);
				bw.RunWorkerAsync();
			}
		}

		public void RunTaskSync()
		{
			if (!bw.IsBusy) {
				RunTaskAsync();

				// Force UI redraw to display CommandInfo before blocking the thread
				if (form != null) {
					form.Invalidate();
					form.Update();
				}
				if (console != null) {
					console.Invalidate();
					console.Update();
				}

				isDone.WaitOne();
			}
		}

		public void StopTask()
		{
			if (bw.IsBusy) {
				bw.CancelAsync();
				isDone.WaitOne();
				writeToConsole("Task finished.");
				muteOutput = true;
			}
		}

		public bool IsRunning
		{
			get { return bw.IsBusy; }
		}


		public static void SetConsole(TextBox console)
		{
			if (console != null) {
				ConsoleTask.console = console;
				ConsoleTask.console.Clear();
			}
		}

		public static void SetForm(Form form)
		{
			if (form != null) {
				ConsoleTask.form = form;
				ConsoleTask.form.FormClosing += form_FormClosing;
			}
		}


		private static void form_FormClosing(object sender, FormClosingEventArgs e)
		{
			int a;
			mux.WaitOne();
			a = runningTasks;
			mux.ReleaseMutex();

			if (a > 0) {
				closePending = true;
				allClosed.WaitOne();
			}
		}
	}
}
