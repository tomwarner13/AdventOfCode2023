using System.Text.RegularExpressions;

namespace AdventOfCode2023.Util;

public static class RegexUtils
{
  public static readonly Regex BasicDigitRegex = new("\\d+", RegexOptions.Compiled);
}