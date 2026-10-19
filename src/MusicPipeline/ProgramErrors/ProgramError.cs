namespace MusicPipeline.Errors;

public class ProgramError
{
	public required string ErrorType {get; set;}
	public string? ErrorData {get; set;} // Maybe required?
	public List<string>? ErrorRaw {get; set;} // If the error is from a section of program output, the output it was gotten from.
}