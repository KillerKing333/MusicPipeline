using MusicPipeline.Results;
using MusicPipeline.Tools.LogEngine;
using MusicPipeline.Profiles;
namespace MusicPipeline.StepHandler;

public static class Handler
{
	public static async Task HandleResult(Result result)
	{
		// It complains endlessly when i miss it out
		// "Profile is a namespace but being used a type"
		// NOTHING USES IT AS A NAMESPACE

		//that's odd. The way it is here Profiles (with an 's') is a namespace
		//	Profile (with no 's') is a Class in that namespace
		//	sublime is weird.
		//In VS, it just marks it with gray text indicating it is unnecessary to specify the namespace here.
		//	doesn't hurt to leave it in there to keep sublime happy.
		//I do think sublime is incorrectly flagging that though.

		
		Profiles.Profile ActiveProfile = await ProfileManager.LoadActiveProfileAsync();

		//on sublime does it give any indication about a possible null reference for the item below?
		LogEngine l = ActiveProfile.LogEngine;
		//I ask because VS does a green squiggly line, and it's so annoying.
		//It happens at work too, and there are two ways to deal with it.
		//one is at the file level, and one at the project level.
		//for file level, you just leave 
			// #nullable disable
		//anywhere in the file.

		//if sublime does squawk about potential null references like that with an annoying squiggly, you should try including that line in this file to see if it disables the warnings.
		//it does in VS.

		l.user = "StepHandler";
		string Success = "";
		// Cookie Verification finished successfully/with errors in (elapsed time)
		if (result.Outcome) {Success = "successfully";} else {Success = "with errors";}

		//here's another way to write success and assignment with a ternary operator.
		//google says: "ternary" comes from the Latin word ternarius, which means "consisting of three items." :)
		string success2 = result.Outcome ? "successfully" : "with errors";
		//condition ? result if true : result if false

		string ElapsedTime = result.Elapsed.ToString(@"dd\:hh\:mm\:ss\.ffff");
		await l.Out($"{result.Step} finished {Success} in {ElapsedTime}");
		// TODO: Metrics database etc
		// As in, make it handle the songs and things that were affected by the step and do what's necessary
	}

	public static async Task HandleResults(List<Result> results)
	{
		foreach (Result result in results) {
			await HandleResult(result);
		}
	}

	public static async Task HandleResults(IEnumerable<Result> results)
	{
		foreach (Result result in results) {
			await HandleResult(result);
		}
	}
}