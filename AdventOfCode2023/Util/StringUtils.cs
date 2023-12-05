namespace AdventOfCode2023.Util;

public static class StringUtils
{
  public static IEnumerable<int> ExtractIntsFromString(string input)
  {
    var matches = RegexUtils.BasicDigitRegex.Matches(input);
    return matches.Select(s => int.Parse(s.ToString()));
  }
  
  
  public static IEnumerable<long> ExtractLongsFromString(string input)
  {
    var matches = RegexUtils.BasicDigitRegex.Matches(input);
    return matches.Select(s => long.Parse(s.ToString()));
  }
}