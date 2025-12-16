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
}
