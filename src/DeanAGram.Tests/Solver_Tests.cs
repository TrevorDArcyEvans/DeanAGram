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

    result.Count().ShouldBe(1);
    var res = result.Single();
    res.ShouldContain("smoked");
    res.ShouldContain("salmon");
  }

  [Test]
  public void GetSolutions_02_succeeds()
  {
    var wordList = new WordList();
    wordList.Add("brake");
    wordList.Add("rake");
    wordList.Add("flake");
    wordList.Add("lake");
    var sut = new Solver(wordList);

    var result = sut.GetSolutions("lake rake".RemoveWhitespace());

    result.Count().ShouldBe(1);
    var res = result.Single();
    res.ShouldContain("lake");
    res.ShouldContain("rake");
  }
}
