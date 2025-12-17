using DeanAGram.API;

namespace DeanAGram.Tests;

[TestFixture]
public sealed class Solver_Tests
{
  [Test]
  public void Constructor_succeeds()
  {
    _ = new Solver(new());
  }
}
