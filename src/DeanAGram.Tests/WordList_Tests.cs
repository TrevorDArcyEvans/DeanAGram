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
}
