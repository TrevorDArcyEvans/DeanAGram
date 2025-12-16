namespace DeanAGram.API;

// [fast key] --> [words[]]
// fast key = unique letters in a word
public sealed class WordList : Dictionary<string, HashSet<string>>
{
  public void Add(string word)
  {
    var fkey = word.FastKey();

    if (!ContainsKey(fkey))
    {
      this[fkey] = new();
    }

    if (!this[fkey].Contains(word))
    {
      this[fkey].Add(word);
    }
  }

  public bool Contains(string word)
  {
    var fkey = word.FastKey();

    return ContainsKey(fkey) && this[fkey].Contains(word);
  }

  public HashSet<string> GetCandidates(string anagram)
  {
    var retVal = new HashSet<string>();

    // fast key = list of unique letters in anagram
    var fkey = anagram.FastKey();

    foreach (var key in Keys)
    {
      // each letter of word must be in anagram
      var containsAll = key.All(ch => fkey.Contains(ch));
      if (!containsAll)
      {
        continue;
      }

      var thisCandidates = this[key];
      retVal.UnionWith(thisCandidates);
    }

    return retVal.Where(anagram.Contains).ToHashSet();
  }
}
