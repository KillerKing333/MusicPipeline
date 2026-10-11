using MusicPipeline.Results;
using MusicPipeline.Tools.LogEngine;
using MusicPipeline.Profiles;
namespace MusicPipeline.StepHandler;

public static class Handler
{
	public static async Task HandleResult(Result result)
	{
		Profile activeProfile = await ProfileManager.LoadActiveProfileAsync();
		LogEngine l = activeProfile.LogEngine ?? new(activeProfile.DiagLogFile);
		l.user = "StepHandler";
		string success = result.Outcome ? "successfully" : "with errors";
		string elapsedTime = result.Elapsed.ToString(@"dd\:hh\:mm\:ss\.ffff");
		await l.Out($"{result.Step} finished {success} in {elapsedTime}");
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