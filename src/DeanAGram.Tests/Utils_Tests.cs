namespace DeanAGram.Tests;

using System.Text.RegularExpressions;
using DeanAGram.API;
using Shouldly;

[TestFixture]
public sealed class Utils_Tests
{
  [TestCase("edcba", "abcde")]
  [TestCase("edcbaedcba", "abcde")]
  [TestCase("ababa", "ab")]
  public void FastKey_returns_expected(string str, string expected)
  {
    var fkey = str.FastKey();

    fkey.ShouldBe(expected);
  }

  [TestCase("edcba", "abcde")]
  [TestCase("edcbaedcba", "abcde")]
  [TestCase("ababa", "ab")]
  public void ContainsWord_contains_returns_true(string anagram, string word)
  {
    anagram.ContainsWord(word).ShouldBeTrue();
  }

  [TestCase("abc", "abcde")]
  [TestCase("zxvnmjkl", "abcde")]
  [TestCase("ab", "ababa")]
  [TestCase("abzzzzzz", "ababa")]
  public void ContainsWord_not_contains_returns_false(string anagram, string word)
  {
    anagram.ContainsWord(word).ShouldBeFalse();
  }

  [TestCase("edcba", "abcde", "")]
  [TestCase("edcbaedcba", "abcde", "edcba")]
  [TestCase("ababa", "ab", "aba")]
  public void GetRemainder_contains_returns_expected(string anagram, string word, string remainder)
  {
    anagram.GetRemainder(word).ShouldBe(remainder);
  }

  [TestCase("edcba", "abfg")]
  [TestCase("abcde", "z")]
  [TestCase("ab", "ababa")]
  public void GetRemainder_not_contains_throws(string anagram, string word)
  {
    Should.Throw<KeyNotFoundException>(() => anagram.GetRemainder(word));
  }

  // Source - https://stackoverflow.com/a
  // Posted by Henk J Meulekamp, modified by community. See post 'Timeline' for change history
  // Retrieved 2025-12-17, License - CC BY-SA 4.0
  [Test]
  [TestCase("123 123 1adc \n 222", "1231231adc222")]
  public void RemoveWhiteSpace1(string input, string expected)
  {
    string s = null;
    for (int i = 0; i < 1000000; i++)
    {
      s = input.RemoveWhitespace();
    }

    expected.ShouldBe(s);
  }

  [Test]
  [TestCase("123 123 1adc \n 222", "1231231adc222")]
  public void RemoveWhiteSpace2(string input, string expected)
  {
    string s = null;
    for (int i = 0; i < 1000000; i++)
    {
      s = Regex.Replace(input, @"\s+", "");
    }

    expected.ShouldBe(s);
  }
}
