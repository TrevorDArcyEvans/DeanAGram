namespace DeanAGram.CLI;

using System.Diagnostics;
using CommandLine;
using DeanAGram.API;

internal static class Program
{
  public static void Main(string[] args)
  {
    var result = Parser.Default.ParseArguments<Options>(args)
      .WithParsed(Run);
    result.WithNotParsed(HandleParseError);
  }

  private static void Run(Options opt)
  {
    var sw = Stopwatch.StartNew();

    var wordList = WordList.FromJsonWordFile(opt.JsonWordFilePath);
    var solver = new Solver(wordList);
    var solns = solver.GetSolutions(opt.Anagram);
    var elapsedMs = sw.ElapsedMilliseconds;

    Console.WriteLine($"Processing:");
    Console.WriteLine($"  {opt.JsonWordFilePath}");
    Console.WriteLine($"  \"{opt.Anagram}\"");
    Console.WriteLine();
    foreach (var soln in solns)
    {
      Console.Write($"  ");
      foreach (var word in soln)
      {
        Console.Write($"{word} ");
      }

      Console.WriteLine();
    }

    Console.WriteLine($"Found {solns.Count()} solutions in {elapsedMs} ms");
  }

  private static void HandleParseError(IEnumerable<Error> errs)
  {
    if (errs.IsVersion())
    {
      Console.WriteLine("Version Request");
      return;
    }

    if (errs.IsHelp())
    {
      Console.WriteLine("Help Request");
      return;
    }

    Console.WriteLine("Parser Fail");
    return;
  }
}
