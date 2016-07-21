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

		private static string jekyllCommandPrefix = "\"" + Path.GetFullPath(CONSTANTS.JEKYLL_PATH) + "\" ";

		public static string IPAddres = "localhost";
		public static uint PortNumber = 4000;
		public static string WorkingDir = "";


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

		public static bool InstallJekyllEnvironment()
		{
			// Check for existing environment
			if (!File.Exists(CONSTANTS.RUBY_PATH) || !File.Exists(CONSTANTS.JEKYLL_PATH)) {
				// Need to install the environment
				if (!File.Exists(CONSTANTS.ARCHIVE_PATH)) {
					Tools.DisplayError("Could not locate \"" + CONSTANTS.ARCHIVE_PATH + "\". Please reinstall this app and try again.");
					return false;
				}
				return Tools.ExtractArchive(CONSTANTS.ARCHIVE_PATH, CONSTANTS.ENV_FOLDER);
			}
			return true;
		}
	}

	static class CONSTANTS
	{
		public const string ROOT_FOLDER = @".";
		public const string SEVEN_ZIP_LIB = ROOT_FOLDER + @"\7z.dll";
		public const string ENV_FOLDER = ROOT_FOLDER + @"\ruby-jekyll-env";
		public const string BIN_FOLDER = ENV_FOLDER + @"\bin";
		public const string RUBY_PATH = BIN_FOLDER + @"\ruby.exe";
		public const string JEKYLL_PATH = BIN_FOLDER + @"\jekyll";
		public const string ARCHIVE_PATH = ROOT_FOLDER + @"\ruby-jekyll-env.7z";
	}
}
