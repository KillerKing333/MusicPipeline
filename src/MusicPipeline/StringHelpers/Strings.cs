namespace MusicPipeline.Strings;

public class StringHelpers 
{
	public static async Task<Dictionary<int, string>> GetLinesDict(string allText)
	{
		List<string> lines = new(allText.Split("\n"));
		Dictionary<int, string>> res = new();
		for (int i = 0; i < (lines.Count()); i++) {
			res.Append(new KeyValuePair<int, string>(i, lines[i]))
		}
		return res;
	}
}