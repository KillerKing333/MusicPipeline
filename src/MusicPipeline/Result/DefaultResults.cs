namespace MusicPipeline.Results;

public static class CookieDefaults
{
	public static Result FileError(bool YTDLP, TimeSpan Elapsed)
	{
		//I changed the flow of this method.
		//See if you like the style.
		//The logic is the same.
		var error = "Cookie file not found";
        if (YTDLP)
            error = "YTDLP executable not found";

		return new Result("Cookie Verification", false, Elapsed, error);
	}
}