namespace DeanAGram.API;

public sealed class Solver(WordList _wordList)
{
  public IEnumerable<IEnumerable<string>> GetSolutions(string anagram)
  {
    var candidates = _wordList.GetCandidates(anagram);

    return [candidates];
  }
}
