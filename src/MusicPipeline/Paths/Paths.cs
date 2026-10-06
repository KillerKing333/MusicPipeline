namespace MusicPipeline;

public class Path
{
	// Hehe idk what I'm doing
	public string path {get => GetStringPath();}
	public required string FullPath {get; set;}
	public string? ConfigDir {get; set;}
	public string? RootDir {get; set;}
	public string? UserDir {get; set;}
	public string? ScriptDir {get; set;}

	public string GetStringPath()
	{
		// Handle path somehow
		string res = TakeFullPathWithPathSyntaxAndTurnItIntoAStringUsingTheGivenPathObjectForDirectoryReferences(this);
		return res;
	}

	internal string TakeFullPathWithPathSyntaxAndTurnItIntoAStringUsingTheGivenPathObjectForDirectoryReferences(Path path)
	{
		// I don't even know how the path syntax works yet so um
		// TODO: this
		return "Shan't";
	}
}