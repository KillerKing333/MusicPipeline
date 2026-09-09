using System.Text.RegularExpressions;
using MusicPipeline.Songs;
using MusicPipeline.Strings;
namespace MusicPipeline.Pipeline.Helpers.Download;

public class YTDLPHelpers
{
	public static string URLPattern = @"\[youtube:tab\] Extracting URL: (https://(?:music.y|www.y|y)outube.co(?:m|.uk)/playlist?list=.*)";
	public static async Task<string> GetUrlFromRunLogFile(string path)
	{
		// Get all text in file
		string match = "";
		string allFileText = await File.ReadAllTextAsync(path);
		List<string> allFileLines = new(allFileText.Split("\n"));
		// Find the url
		foreach (string line in allFileLines) {
			if (Regex.IsMatch(line, URLPattern)) {
				match = Regex.Match(line, URLPattern).Value;
			}
		}
		return match;
	}

	public static async Task<Dictionary<int, SongIdentifier>> GetAllSongsFromRunLogFile(string path)
	{
		// Get all text in file
		string allFileText = await File.ReadAllTextAsync(path);
		Dictionary<int, string> allFileLinesNumbered = new(await StringHelpers.SplitLinesDict(allFileText));
		// Get all the text between each song decleration, including the number

		// Go through each match and check it for being a song

		return new();
	}
}
