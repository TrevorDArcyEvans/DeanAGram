namespace DeanAGram.API;

public static class Utils
{
  public static string FastKey(this string str)
  {
    var unique = str.ToCharArray().Distinct().ToList();
    unique.Sort();
    return new string(unique.ToArray());
  }
}
