namespace DeanAGram.API;

public sealed class Solver(WordList _wordList)
{
  public IEnumerable<IEnumerable<string>> GetSolutions(string anagram)
  {
    var retval = new List<List<string>>();
    var candidates = _wordList.GetCandidates(anagram);

    foreach (var candidate in candidates)
    {
      ProcessCandidate(retval, new(), candidate, anagram);
    }

    // dedupe results
    foreach (var soln in retval)
    {
      soln.Sort();
    }

    var dupeList = new List<List<string>>();
    for (var i = 0; i < retval.Count - 1; i++)
    {
      for (var j = i + 1; j < retval.Count; j++)
      {
        if (retval[i].SequenceEqual(retval[j]))
        {
          dupeList.Add(retval[j]);
        }
      }
    }

    foreach (var dupe in dupeList)
    {
      retval.Remove(dupe);
    }

    return retval;
  }

  private void ProcessCandidate(List<List<string>> retval, List<string> thisSoln, string candidate, string anagram)
  {
    thisSoln.Add(candidate);
    var remainder = anagram.GetRemainder(candidate);
    if (string.IsNullOrEmpty(remainder))
    {
      // last word is wholly in anagram
      retval.Add(thisSoln);
      return;
    }

    var candidates = _wordList.GetCandidates(remainder);
    foreach (var otherCandidate in candidates)
    {
      var otherSoln = new List<string>(thisSoln);
      ProcessCandidate(retval, otherSoln, otherCandidate, remainder);
    }
  }
}
