namespace DeanAGram.CLI;

using CommandLine;

internal sealed class Options
{
  [Value(index: 0, Required = true, HelpText = "Path to JSON word file")]
  public string JsonWordFilePath { get; set; }

  [Value(index: 1, Required = true, HelpText = "Anagram text without spaces")]
  public string Anagram { get; set; }
}
