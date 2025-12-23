namespace DeanAGram.API;

using Newtonsoft.Json;

// [fast key] --> [words[]]
// fast key = unique letters in a word
public sealed class WordList : Dictionary<string, HashSet<string>>
{
  public static WordList FromJsonWordFile(string jsonWordFilePath)
  {
    var json = File.ReadAllText(jsonWordFilePath);
    return JsonConvert.DeserializeObject<WordList>(json);
  }

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

    foreach (var key in Keys)
    {
      // each letter of word must be in anagram 
      var words = this[key];
      foreach (var word in words)
      {
        if (anagram.ContainsWord(word))
        {
          retVal.Add(word);
        }
      }
    }

    return retVal;
  }
}
