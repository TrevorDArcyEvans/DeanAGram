namespace DeanAGram.Tests;

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
}
