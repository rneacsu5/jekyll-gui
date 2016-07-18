using System.Diagnostics;
using System.IO;

namespace jekyll_gui
{
	public static class JekyllEnv
	{

		public enum JekyllCommand
		{
			CREATE_SITE,
			BUILD_SITE,
			SERVE_SITE
		}

		public static string IPAddres = "localhost";
		public static int PortNumber = 4000;
		public static string WorkingDir = "";


		private static string jekyllCommandPrefix = "\"" + Path.GetFullPath(CONSTANTS.JEKYLL_PATH) + "\" ";

		public static void SetJekyllConsoleTask(ConsoleTask task, JekyllCommand cmd)
		{
			switch (cmd) {
				case JekyllCommand.CREATE_SITE:
					task.SetCommandLine(CONSTANTS.RUBY_PATH, jekyllCommandPrefix + "new . --force", WorkingDir);
					task.CommandInfo = "Creating site...";
					break;
				case JekyllCommand.BUILD_SITE:
					task.SetCommandLine(CONSTANTS.RUBY_PATH, jekyllCommandPrefix + "build", WorkingDir);
					task.CommandInfo = "Building site...";
					break;
				case JekyllCommand.SERVE_SITE:
					task.SetCommandLine(CONSTANTS.RUBY_PATH, jekyllCommandPrefix + "serve -H " + IPAddres + " -P " + PortNumber, WorkingDir);
					task.CommandInfo = "Starting server...";
					break;
			}
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
