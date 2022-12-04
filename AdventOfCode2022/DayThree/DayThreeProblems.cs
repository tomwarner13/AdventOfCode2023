using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayThree
{
  public static class DayThreeProblems
  {
    public static int CalculatePackPriorityScore(IEnumerable<string> input)
    {
      var total = 0;
      foreach (var line in input)
      {
        var (first, second) = SplitString(line);
        var commonChar = FindCommonCharacter(first, second);
        var value = GetCharValue(commonChar);
        total += value;
      }

      return total;
    }

    public static int CalculatePackPriorityScoreFromInputFile(string filepath)
    {
      var input = File.ReadAllLines(filepath);
      return CalculatePackPriorityScore(input);
    }

    public static int CalculateBadgePriorityScore(IEnumerable<string> input)
    {
      var total = 0;
      var accumulator = new string[3];
      var curLine = 0;

      foreach (var line in input)
      {
        var mod = curLine % 3;
        accumulator[mod] = line;

        if (mod == 2)
        {
          //find common badge stuff and add to total
          var commonChar = FindCommonCharBetweenLines(accumulator);
          total += GetCharValue(commonChar);
        }

        curLine++;
      }

      return total;
    }

    public static int CalculateBadgePriorityScoreFromInputFile(string filepath)
    {
      var input = File.ReadAllLines(filepath);
      return CalculateBadgePriorityScore(input);
    }

    private static char FindCommonCharBetweenLines(string[] lines)
    {
      var firstHash = lines[0].ToHashSet();
      firstHash.IntersectWith(lines[1]);
      firstHash.IntersectWith(lines[2]);

      return firstHash.First();
    }

    private static (string firstHalf, string secondHalf) SplitString(string input)
    {
      var totalCount = input.Length;
      var firstHalf = input[..(totalCount / 2)];
      var secondHalf = input[(totalCount / 2)..];

      return (firstHalf, secondHalf);
    }

    private static char FindCommonCharacter(string firstHalf, string secondHalf)
    {
      var firstHash = firstHalf.ToHashSet();
      firstHash.IntersectWith(secondHalf);
      return firstHash.First();
    }

    private static int GetCharValue(char c)
    {
      var i = (int)c;
      if (i < 91) //uppercase
        return i - 38;
      return i - 96; //lowercase
    }
  }
}
