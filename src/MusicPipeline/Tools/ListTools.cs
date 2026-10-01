namespace MusicPipeline.Tools.ListTools;

public class ListTools
{
	public static async Task<(int Length, string Name)> MaxCountAnyList(Dictionary<string, IEnumerable<string>> target)
	{
		// TODO: add a check for the currently nonexistent subset property of compressed directories
		KeyValuePair<string, int> highest = new KeyValuePair<string, int>();

		foreach(KeyValuePair<string, IEnumerable<string>> kvp in target) {
			//var files = masterFiles.Count < MaxCountAnyList(compressedFiles) ? compressedFiles : masterFiles;
			highest = kvp.Value.Count() > highest.Value ? new KeyValuePair<string, int>(kvp.Key, kvp.Value.Count()) : highest;
		}
		return (highest.Value, highest.Key);
	}

	public static async Task<(int Length, string Name)> MaxCountAnyList(Dictionary<string, List<string>> target)
	{
		KeyValuePair<string, int> highest = new KeyValuePair<string, int>();

		foreach(KeyValuePair<string, List<string>> kvp in target) {
			//var files = masterFiles.Count < MaxCountAnyList(compressedFiles) ? compressedFiles : masterFiles;
			highest = kvp.Value.Count() > highest.Value ? new KeyValuePair<string, int>(kvp.Key, kvp.Value.Count()) : highest;
		}
		return (highest.Value, highest.Key);
	}
}