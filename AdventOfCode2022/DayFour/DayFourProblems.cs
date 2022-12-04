using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayFour
{
  public static class DayFourProblems
  {
    public static int CalculateDuplicateAssignmentScore(IEnumerable<string> input)
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

    public static int CalculateOverlapAssignmentScoreFromInputFile(string filepath)
    {
      var input = File.ReadAllLines(filepath);
      return CalculateOverlapAssignmentScore(input);
    }

    public static int CalculateOverlapAssignmentScore(IEnumerable<string> input)
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

    public static int CalculateDuplicateAssignmentScoreFromInputFile(string filepath)
    {
      var input = File.ReadAllLines(filepath);
      return CalculateDuplicateAssignmentScore(input);
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
