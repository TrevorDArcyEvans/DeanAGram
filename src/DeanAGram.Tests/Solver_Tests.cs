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

  [Test]
  public void GetSolutions_03_multiple_succeeds()
  {
    var wordList = new WordList
    {
      "I".ToLowerInvariant(),
      "am".ToLowerInvariant(),
      "Lord".ToLowerInvariant(),
      "Lot".ToLowerInvariant(),
      "Voldemort".ToLowerInvariant(),
      "mail".ToLowerInvariant(),
      "to".ToLowerInvariant(),
      "a".ToLowerInvariant(),
      "or".ToLowerInvariant()
    };
    var sut = new Solver(wordList);

    var result = sut.GetSolutions("Tom Marvolo Lot Riddle".ToLowerInvariant().RemoveWhitespace());

    result.Count().ShouldBe(2);

    //  "I am Lord Lot Voldemort"
    var res1 = result.Single(x =>
      x.Contains("I".ToLowerInvariant()) &&
      x.Contains("am".ToLowerInvariant()) &&
      x.Contains("Lord".ToLowerInvariant()) &&
      x.Contains("Lot".ToLowerInvariant()) &&
      x.Contains("Voldemort".ToLowerInvariant()));
    res1.Count().ShouldBe(5);

    //  "mail to Lord Voldemort"
    var res2 = result.Single(x =>
      x.Contains("mail".ToLowerInvariant()) &&
      x.Contains("to".ToLowerInvariant()) &&
      x.Contains("Lord".ToLowerInvariant()) &&
      x.Contains("Voldemort".ToLowerInvariant()));
    res2.Count().ShouldBe(4);
  }
}
