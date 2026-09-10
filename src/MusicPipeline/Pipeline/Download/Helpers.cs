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
		// Get all text in file
		MatchCollection? matchCollection = null;
		string allFileText = await File.ReadAllTextAsync(path);
		Dictionary<int, string> allFileLinesNumbered = new(await StringHelpers.SplitLinesDict(allFileText));
		/*Dictionary<(int line, int song), (int line, int songEnd)> songToLine = new();
		foreach (KeyValuePair<int, string> kvp in allFileLinesNumbered) {
			int curSong = 0;
			if (Regex.IsMatch(kvp.Value, SongDeclarePattern)) {
				matchCollection = Regex.Matches(kvp.Value, SongDeclarePattern);
				foreach (Match match in matchCollection) {
					if (i == 0) {
						curSong = int.Parse(match.Value);
					} else {
						total = int.Parse(match.Value);
					}
					i++;
				}
			}
			songToLine.Append((kvp.Key, curSong));
		}
		// Get all the text between each song decleration, including the number
		foreach ((int lineNum, string line) in allFileLinesNumbered) {
			// So we have the current line number
			// We need to test if it is between any pair 

		}*/
		bool inSong = false;
		List<(int line, int song)> songStarts = new();
		List<(int line, int song)> songEnds = new();
		foreach (KeyValuePair<int, string> kvp in allFileLinesNumbered) {
			if (Regex.IsMatch(kvp.Value, SongDeclarePattern)) {
				matchCollection = Regex.Matches(kvp.Value, SongDeclarePattern);
				// So we have the current line number as well as the matches
				if (!inSong) {
					inSong = true;
					songStarts.Add((kvp.Key, int.Parse(matchCollection[0].Value)));
				} else {
					inSong = false;
					songEnds.Add((kvp.Key, int.Parse(matchCollection[0].Value)));
				}
			}
		}
		
		// Go through each match and check it for being a song

		return new();
	}
}
