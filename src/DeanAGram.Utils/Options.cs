namespace DeanAGram.Utils;

using CommandLine;

internal sealed class Options
{
  [Value(index: 0, Required = true, HelpText = "Path to word file (one per line)")]
  public string WordFile1Path { get; set; }
}
