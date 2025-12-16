namespace DeanAGram.Tests;

using DeanAGram.API;
using Shouldly;

[TestFixture]
public sealed class WordList_Tests
{
  [TestCase("edcba")]
  [TestCase("edcbaedcba")]
  [TestCase("ababa")]
  public void WordList_Add_adds_word(string word)
  {
    var words = new WordList { word };

    words.Keys.Count.ShouldBe(1);
    words[words.Keys.Single()].Single().ShouldBe(word);
  }

  [TestCase("edcba")]
  [TestCase("edcbaedcba")]
  [TestCase("ababa")]
  public void WordList_Add_twice_adds_word_once(string word)
  {
    var words = new WordList { word, word };

    words.Keys.Count.ShouldBe(1);
    words[words.Keys.Single()].Single().ShouldBe(word);
  }

  [Test]
  public void Contains_not_contains_returns_false()
  {
    var words = new WordList { "edcba", "edcbaedcba" };

    words.Contains(Guid.NewGuid().ToString()).ShouldBeFalse();
  }

  [Test]
  public void Contains_contains_returns_true()
  {
    const string word1 = "edcba";
    const string word2 = "edcbaedcba";
    
    var words = new WordList { word1, word2 };

    words.Contains(word1).ShouldBeTrue();
    words.Contains(word2).ShouldBeTrue();
  }

  [Test]
  public void GetCandidates_contains_returns_true()
  {
    const string word1 = "edcba";
    const string word2 = "ba";
    const string word3 = "dcb";
    const string anagram = "edcbaedcba";
    
    var words = new WordList { word1, word2, word3 };

    words.GetCandidates(anagram).Contains(word1).ShouldBeTrue();
    words.GetCandidates(anagram).Contains(word2).ShouldBeTrue();
    words.GetCandidates(anagram).Contains(word3).ShouldBeTrue();
  }

  [Test]
  public void GetCandidates_not_contains_returns_false()
  {
    const string word1 = "edcba";
    const string word2 = "ba";
    const string word3 = "dcb";
    const string anagram = "zxvnmjkl";
    
    var words = new WordList { word1, word2, word3 };
    var candidates = words.GetCandidates(anagram);

    candidates.Contains(word1).ShouldBeFalse();
    candidates.Contains(word2).ShouldBeFalse();
    candidates.Contains(word3).ShouldBeFalse();
  }

  [Test]
  public void GetCandidates_short_anagram_returns_empty()
  {
    const string word1 = "edcba";
    const string word2 = "ba";
    const string word3 = "dcb";
    const string anagram = "a";
    
    var words = new WordList { word1, word2, word3 };
    var candidates = words.GetCandidates(anagram);

    candidates.ShouldBeEmpty();
  }
}
