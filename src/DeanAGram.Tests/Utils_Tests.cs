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
  public void ContainsWord_not_contains_returns_false(string anagram, string word)
  {
    anagram.ContainsWord(word).ShouldBeFalse();
  }
}
