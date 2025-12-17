namespace DeanAGram.API;

public sealed class Solver(WordList wordList)
{
  private readonly WordList _wordList = wordList;

  public IEnumerable<string> GetSolutions(string anagram)
  {
    return Enumerable.Empty<string>();
  }
}
