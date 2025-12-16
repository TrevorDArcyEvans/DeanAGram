namespace DeanAGram.API;

// [fast key] --> [words[]]
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
}
