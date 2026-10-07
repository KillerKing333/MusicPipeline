using System.Text.RegularExpressions;
namespace MusicPipeline;

public class MyPath
{
	// Hehe idk what I'm doing
	// ~ is UserDir
	// Others are [$VarName]
	// I guess I make regexes for those at some point
	// Root script and config can be done from the running directory
	// And ConfigDir is being kept as a variable so that I can make it use sandbox right now and move it to main repo later.
	public string path {get => GetStringPath();}
	public required string FormattedPath {get; set;}
	public string? ConfigDir {get; set;}
	public string? RootDir {get; set;}
	public string? UserDir {get; set;}
	public string? ScriptDir {get; set;}

	public string GetStringPath()
	{
		// Handle path somehow
		string res = TakeFullPathWithMyPathSyntaxAndTurnItIntoAStringUsingTheGivenPathObjectForDirectoryReferences(this);
		return res;
	}

	internal string TakeFullPathWithMyPathSyntaxAndTurnItIntoAStringUsingTheGivenPathObjectForDirectoryReferences(MyPath path)
	{
		// I don't even know how the path syntax works yet so um
		// Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		// From https://stackoverflow.com/users/24472/larry

		// Find every ~ and replace with UserDir
		// Find every thing between [$ and ] and replace the whole thing with that property in this class. same logic as the parser
		// Perfect
		// TODO: this

		return "Shan't";
	}

	public MyPath(string formattedPath)
	{
		// Returns C:\Users\(Username) on my machine
		UserDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		ScriptDir = Directory.GetCurrentDirectory();
		RootDir = Directory.GetParent(ScriptDir)?.Parent?.FullName;
		ConfigDir = $"{RootDir}/";
	}
}