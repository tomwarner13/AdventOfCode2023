using System.Text.RegularExpressions;
using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day1;

public class Day1Problems : Problems
{
  private static readonly Regex BasicDigitRegex = new("\\d", RegexOptions.Compiled);
  private static readonly Regex LetterDigitRegex = new("(?=(\\d|one|two|three|four|five|six|seven|eight|nine))", RegexOptions.Compiled);

  protected override string TestInput => @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

  protected override int Day => 1;

  protected override string Problem1(string[] input, bool isTestInput)
  {
    return CalculateDigitSum(input).ToString();
  }

  protected override string Problem2(string[] input, bool isTestInput)
  {
    return CalculateDigitSumWithLetters(input).ToString();
  }

  private static int CalculateDigitSum(IEnumerable<string> input)
  {
    return input.Sum(ParseDigitsFromString);
  }

  private static int ParseDigitsFromString(string inputLine)
  {
    var digits = BasicDigitRegex.Matches(inputLine).ToArray();
    var firstDigit = digits.First().ToString()[0];
    var lastDigit = digits.Last().ToString()[0];
    var foundNumber = $"{firstDigit}{lastDigit}";
    return int.Parse(foundNumber);
  }
  
  private static int CalculateDigitSumWithLetters(IEnumerable<string> input)
  {
    return input.Sum(ConvertToDigitsWithLetters);
  }
  
  private static int ConvertToDigitsWithLetters(string inputLine)
  {
    var digits = LetterDigitRegex.Matches(inputLine).ToArray();
    var firstDigit = PreprocessDigitString(digits.First().Groups[1].ToString());
    var lastDigit = PreprocessDigitString(digits.Last().Groups[1].ToString());
    var foundNumber = $"{firstDigit}{lastDigit}";
    return int.Parse(foundNumber);
  }

  private static string PreprocessDigitString(string input)
  {
    if (input.Length == 1) return input;
    
    return input.Replace("one", "1")
      .Replace("two", "2")
      .Replace("three", "3")
      .Replace("four", "4")
      .Replace("five", "5")
      .Replace("six", "6")
      .Replace("seven", "7")
      .Replace("eight", "8")
      .Replace("nine", "9");
  }
}