namespace MusicPipeline.Paths
{
	public class PathsClass
	{
		public PathsClass(string userDirectory)
		{
			UserDirectory = userDirectory;
			RootDirectory = UserDirectory + "MusicPipeline/";
			ConfigurationDirectory = RootDirectory + "Config/";
			ScriptDirectory = RootDirectory + "src/MusicPipeline/";
		}

		public PathsClass()
		{
			UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).Replace(@"\", "/");
			RootDirectory = Directory.GetCurrentDirectory().Replace(@"\", "/");
			ScriptDirectory = $"{RootDirectory}/Sandbox/Config";
			ConfigurationDirectory = Directory.GetParent(ScriptDirectory)?.Parent?.FullName.Replace(@"\", "/") ?? "";			
		}

		public override string ToString()
		{
			return @$"The User directory is '{UserDirectory}. 
The Root directory is {RootDirectory}.
The Script directory is {ScriptDirectory}.
The Configuration directory is {ConfigurationDirectory}.";
		}

		public string UserDirectory { get;}
		public string RootDirectory { get;}
		public string ConfigurationDirectory { get;}
		public string ScriptDirectory { get;}
	}
}
