namespace DeanAGram.Tests;

using DeanAGram.API;
using Shouldly;

[TestFixture]
public sealed class Solver_Tests
{
  [Test]
  public void Constructor_succeeds()
  {
    _ = new Solver(new());
  }

  [Test]
  public void GetSolutions_01_succeeds()
  {
    var wordList = new WordList();
    wordList.Add("salve");
    wordList.Add("smoked");
    wordList.Add("salmon");
    wordList.Add("swirl");
    var sut = new Solver(wordList);

    var result = sut.GetSolutions("salmon smoked".RemoveWhitespace());

    result.Count().ShouldBe(2);
    result.ShouldContain("smoked");
    result.ShouldContain("salmon");
  }
}
