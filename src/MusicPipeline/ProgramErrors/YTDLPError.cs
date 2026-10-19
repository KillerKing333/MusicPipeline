namespace MusicPipeline.Errors;

public class YTDLPError : ProgramError
{
	// IDK

	public YTDLPError(List<string> logOutput)
	{
		ErrorRaw = logOutput;
		ErrorType = GetErrorTypeFromOutput(logOutput);
		ErrorData = GetErrorDataFromOutput(logOutput);
	}

	private string GetErrorTypeFromOutput(List<string> logOutput)
	{
		Console.WriteLine("TODO");
		return "TODO";
	}

	private string GetErrorDataFromOutput(List<string> logOutput)
	{
		Console.WriteLine("TODO");
		return "TODO";
	}
}