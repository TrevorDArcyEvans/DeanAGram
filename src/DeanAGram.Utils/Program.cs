namespace DeanAGram.Utils;

using CommandLine;
using DeanAGram.API;
using Newtonsoft.Json;

internal static class Program
{
  public static async Task Main(string[] args)
  {
    var result = await Parser.Default.ParseArguments<Options>(args)
      .WithParsedAsync(Run);
    await result.WithNotParsedAsync(HandleParseError);
  }

  private static async Task Run(Options opt)
  {
    var wordList = new WordList();
    var words = File.ReadAllLines(opt.WordFile1Path).Select(x => x.ToLowerInvariant());
    foreach (var word in words)
    {
      wordList.Add(word);
    }

    var json = JsonConvert.SerializeObject(wordList, Formatting.Indented);
    var jsonWordListFilePath = Path.ChangeExtension(opt.WordFile1Path, "json");
    await File.WriteAllTextAsync(jsonWordListFilePath, json);
  }

  private static Task HandleParseError(IEnumerable<Error> errs)
  {
    if (errs.IsVersion())
    {
      Console.WriteLine("Version Request");
      return Task.CompletedTask;
    }

    if (errs.IsHelp())
    {
      Console.WriteLine("Help Request");
      return Task.CompletedTask;
      ;
    }

    Console.WriteLine("Parser Fail");
    return Task.CompletedTask;
  }
}
