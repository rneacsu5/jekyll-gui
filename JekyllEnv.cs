using System.Diagnostics;
using System.IO;

namespace jekyll_gui {
	public static class JekyllEnv {

		private static Process CreateRubyProcess(string args, string workingDir) {
			Process p = new Process();

			p.StartInfo.UseShellExecute = false;
			p.StartInfo.CreateNoWindow = true;

			p.StartInfo.FileName = Path.GetFullPath(CONSTANTS.RUBY_PATH);
			p.StartInfo.Arguments = args;
			p.StartInfo.WorkingDirectory = workingDir;

			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.RedirectStandardError = true;

			return p;
		}

		public static Process CreateJekyllProcess(string args, string workingDir) {
			return CreateRubyProcess("\"" + Path.GetFullPath(CONSTANTS.JEKYLL_PATH) +"\" " + args, workingDir);
		}
	}
}
