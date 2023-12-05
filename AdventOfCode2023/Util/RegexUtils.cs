using System.Text.RegularExpressions;

namespace AdventOfCode2023.Util;

public static class RegexUtils
{
  public static readonly Regex BasicDigitRegex = new("\\d+", RegexOptions.Compiled);
  public static readonly Regex BasicLetterRegex = new("[A-Za-z]+", RegexOptions.Compiled);
}