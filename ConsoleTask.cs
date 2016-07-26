using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System;
using System.Drawing;

namespace jekyll_gui
{

	public class ConsoleTask
	{
		private static Form form = null;
		private static RichTextBox console = null;
		private static bool closePending = false;
		private static AutoResetEvent allClosed = new AutoResetEvent(false);
		private static int runningTasks = 0;
		private static Mutex mux = new Mutex();

		public string CommandInfo;
		private Process proc = new Process();
		private BackgroundWorker bw = new BackgroundWorker();
		private AutoResetEvent isDone = new AutoResetEvent(false);


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

			try {
				proc.Start();
				proc.BeginOutputReadLine();
				proc.BeginErrorReadLine();

				while (!proc.HasExited && !bw.CancellationPending && !closePending) Thread.Sleep(100);
				if (!proc.HasExited) proc.Kill();
				if (bw.CancellationPending) e.Cancel = true;

				proc.CancelOutputRead();
				proc.CancelErrorRead();
			}
			catch (Exception exception) {
				Tools.DisplayError("Could not start process. Make sure the project exists and then retry.", exception);
				e.Cancel = true;
			}

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


		public void SetCommandLine(string command, string args, string workingDir)
		{
			proc.StartInfo.FileName = command;
			proc.StartInfo.Arguments = args;
			proc.StartInfo.WorkingDirectory = workingDir;
		}

		public void RunTaskAsync()
		{
			if (!bw.IsBusy) {
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
				setConsoleColor();
			}
		}

		public void StopTask()
		{
			if (bw.IsBusy) {
				bw.CancelAsync();
				isDone.WaitOne();
				setConsoleColor();
			}
		}

		public bool IsRunning
		{
			get { return bw.IsBusy; }
		}

		public void AddTaskCompleteEventHandler(RunWorkerCompletedEventHandler h)
		{
			bw.RunWorkerCompleted += h;
		}


		public static void SetConsole(RichTextBox console)
		{
			if (console != null) {
				ConsoleTask.console = console;
				ConsoleTask.console.Clear();
				setConsoleColor();
			}
		}

		public static void SetForm(Form form)
		{
			if (form != null) {
				ConsoleTask.form = form;
				ConsoleTask.form.FormClosing += form_FormClosing;
			}
		}


		private static void setConsoleColor() { setConsoleColor(Color.Empty); }

		private static void setConsoleColor(Color c)
		{
			if (console != null && !console.IsDisposed) {
				console.SelectionStart = console.TextLength;
				console.SelectionLength = 0;
				console.SelectionColor = (c == Color.Empty) ? console.ForeColor : c;
			}
		}

		private static void writeToConsole(string line)
		{
			if (console != null && !console.IsDisposed && line != null) {
				int a;
				while ((a = line.IndexOf("\x1b[")) >= 0) {
					console.AppendText(line.Substring(0, a));
					line = line.Remove(0, a + 2);
					if (line.Length < 2) return;
					if (line[0] == '0' && line[1] == 'm') {
						setConsoleColor();
						line = line.Remove(0, 2);
					}
					else {
						if (line.Length < 3) return;
						if (line.Substring(0, 3) == "31m") {
							setConsoleColor(Color.Red);
							line = line.Remove(0, 3);
						}
						else if (line.Substring(0, 3) == "33m") {
							setConsoleColor(Color.Yellow);
							line = line.Remove(0, 3);
						}
						else if (line[2] == 'm') line = line.Remove(0, 3);
					}
				}
				console.AppendText(line);
				console.AppendText(Environment.NewLine);
			}
		}

		private static void clearConsole()
		{
			if (console != null && !console.IsDisposed) {
				console.Clear();
				setConsoleColor(console.ForeColor);
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
