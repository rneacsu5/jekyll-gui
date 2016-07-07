using System.Diagnostics;
using System.IO;

namespace jekyll_gui
{
	public static class JekyllEnv
	{

		private static Process CreateRubyProcess(string args, string workingDir)
		{
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

		public static Process CreateJekyllProcess(string args, string workingDir)
		{
			return CreateRubyProcess("\"" + Path.GetFullPath(CONSTANTS.JEKYLL_PATH) + "\" " + args, workingDir);
		}
	}

	static class CONSTANTS
	{
		public static string ROOT_FOLDER = @"Data";
		public static string SEVEN_ZIP_LIB = ROOT_FOLDER + @"\7z.dll";
		public static string ENV_FOLDER = ROOT_FOLDER + @"\ruby-jekyll-env";
		public static string BIN_FOLDER = ENV_FOLDER + @"\bin";
		public static string RUBY_PATH = BIN_FOLDER + @"\ruby.exe";
		public static string JEKYLL_PATH = BIN_FOLDER + @"\jekyll";
		public static string ARCHIVE_PATH = ROOT_FOLDER + @"\ruby-jekyll-env.7z";
	}

}
