using System.Text.RegularExpressions;
using MusicPipeline.Songs;
using MusicPipeline.Strings;
namespace MusicPipeline.Pipeline.Helpers.Download;

public class YTDLPHelpers
{
	public static string URLPattern = @"\[youtube:tab\] Extracting URL: (https://(?:music.y|www.y|y)outube.co(?:m|.uk)/playlist?list=.*)";
	public static string SongDeclarePattern = @"\[download\] Downloading item (\d+) of (\d+)";
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

	public static async Task<Dictionary<int, SongIdentifier>> GetSongsFromRunLogFile(string path)
	{
		return (await GetAllSongsFromRunLogFile(path)).songs;
	}

	public static async Task<(int total, Dictionary<int, SongIdentifier> songs)> GetAllSongsFromRunLogFile(string path)
	{
		int total = 0;
		int i = 0;
		// Get all text in file
		MatchCollection? matchCollection = null;
		string allFileText = await File.ReadAllTextAsync(path);
		Dictionary<int, string> allFileLinesNumbered = new(await StringHelpers.SplitLinesDict(allFileText));
		Dictionary<int, int> songToLine = new();
		foreach (KeyValuePair<int, string> kvp in allFileLinesNumbered) {
			//KeyValuePair<int, int> 
			if (Regex.IsMatch(kvp.Value, SongDeclarePattern)) {
				matchCollection = Regex.Matches(kvp.Value, SongDeclarePattern);
				foreach (Match match in matchCollection) {
					if (i == 0) {
						//songToLine. = 
					}
				}
			}

		}
		// Get all the text between each song decleration, including the number

		// Go through each match and check it for being a song

		return new();
	}
}
