using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day4
{
  public class Day4Problems : Problems
  {
    public override string TestInput => @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
    public override int Day => 4;
    public override string Problem1(string[] input, bool isTestInput)
    {
      return CalculateDuplicateAssignmentScore(input).ToString();
    }

    public override string Problem2(string[] input, bool isTestInput)
    {
      return CalculateOverlapAssignmentScore(input).ToString();
    }

    private static int CalculateDuplicateAssignmentScore(IEnumerable<string> input)
    {
      var total = 0;
      foreach (var line in input)
      {
        var parsed = ParseLine(line);
        if (CheckIfRangeContained(parsed.first, parsed.second))
        {
          total += 1;
        }
      }

      return total;
    }

    private static int CalculateOverlapAssignmentScore(IEnumerable<string> input)
    {
      var total = 0;
      foreach (var line in input)
      {
        var parsed = ParseLine(line);
        if (CheckIfAnyOverlap(parsed.first, parsed.second))
        {
          total += 1;
        }
      }

      return total;
    }

    private static ((int, int) first, (int, int) second) ParseLine(string line)
    {
      var halves = line.Split(',');
      return (ParseRange(halves[0]), ParseRange(halves[1]));
    }

    private static (int, int) ParseRange(string range)
    {
      var nums = range.Split('-');
      return (int.Parse(nums[0]), int.Parse(nums[1]));
    }

    private static bool CheckIfRangeContained((int, int) first, (int, int) second)
    {
      return ((first.Item1 >= second.Item1) && (first.Item2 <= second.Item2)) ||
             ((second.Item1 >= first.Item1) && (second.Item2 <= first.Item2));
    }
    private static bool CheckIfAnyOverlap((int, int) first, (int, int) second)
    {
      return ((first.Item1 >= second.Item1) && (first.Item1 <= second.Item2)) ||
             ((second.Item1 >= first.Item1) && (second.Item1 <= first.Item2));
    }
  }
}
