namespace MusicPipeline.Alerts;

//you're not really using this class yet, so it can change back to a class instead of a record if
//	in the futrue you end up needing behavior.
//records are great for simple classes where the data is the focus.

/*
Best Practices for records

While records can hold behavior (methods), they are primarily designed to be immutable data carriers. 
If you write methods inside a record, keep these principles in mind:
• Avoid mutating state: Instead of modifying fields directly inside the method, 
	your methods should generally compute values or return a new instance of the record using the with expression.
• Keep them data-centric: Use methods for formatting, validation, or simple transformations. 
	If your type requires heavy business logic, state machines, or complex lifecycle behaviors, 
	a standard C# class is usually the better tool.
 */
public record Alert(string Type, string FixAction, string Message);
//{
//	public required string Type {get; set;}
//	public required string FixAction {get; set;}
//	public required string Message {get; set;}
//}
