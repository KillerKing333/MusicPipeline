namespace MusicPipeline.Paths
{
	//my intention behind this class was to compare it to your MyPaths.
	//I don't currently understand why MyPaths does the encoding thing,
	//	but as you complete it, I believe that will be revealed.
	//Then I'd like to see if I can modify this class to satisfy the same needs,
	//	possibly in a different way.
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
