namespace MusicPipeline.Metrics;

public class Metric
{
	// TODO: finish
	public int MasterCount {get; set;}
	public List<int>? CompressedCounts {get; set;}
	public int LrcCount {get; set;}
	public double MasterSize {get; set;}
	public List<double>? CompressedSizes {get; set;}
}