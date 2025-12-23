namespace DeanAGram.API;

public static class Utils
{
  public static string FastKey(this string str)
  {
    var unique = str.ToCharArray().Distinct().ToList();
    unique.Sort();
    return new string(unique.ToArray());
  }

  public static bool ContainsWord(this string anagram, string word)
  {
    if (anagram.Length < word.Length)
    {
      return false;
    }

    var aChars = GetCharacterCounts(anagram);
    var wChars = GetCharacterCounts(word);

    foreach (var wkvp in wChars)
    {
      if (!aChars.ContainsKey(wkvp.Key))
      {
        // word char not in anagram
        return false;
      }

      if (aChars[wkvp.Key] < wkvp.Value)
      {
        // not enough of this (word) char in anagram
        return false;
      }
    }

    return true;
  }

  public static string GetRemainder(this string anagram, string word)
  {
    var aChars = anagram.ToCharArray().ToList();
    var wChars = word.ToCharArray();

    foreach (var wChar in wChars)
    {
      if (!aChars.Remove(wChar))
      {
        throw new KeyNotFoundException();
      }
    }

    return new string(aChars.ToArray());
  }

  // Source - https://stackoverflow.com/a
  // Posted by Henk J Meulekamp, modified by community. See post 'Timeline' for change history
  // Retrieved 2025-12-17, License - CC BY-SA 4.0
  public static string RemoveWhitespace(this string input)
  {
    return new string(input
      .Where(c => !Char.IsWhiteSpace(c))
      .ToArray());
  }

  private static readonly IDictionary<string, IDictionary<char, int>> _wordCharCounts = new Dictionary<string, IDictionary<char, int>>();

  private static IDictionary<char, int> GetCharacterCounts(string anagram)
  {
    if (_wordCharCounts.ContainsKey(anagram))
    {
      return _wordCharCounts[anagram];
    }

    var newCharCount = anagram
      .GroupBy(c => c)
      .Select(c => new { Char = c.Key, Count = c.Count() })
      .ToDictionary(x => x.Char, x => x.Count);

    _wordCharCounts[anagram] = newCharCount;

    return newCharCount;
  }
}
