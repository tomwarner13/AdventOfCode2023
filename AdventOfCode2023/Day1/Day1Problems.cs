using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day1;

public class Day1Problems : Problems
{
  public override string TestInput => @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

  public override int Day => 1;

  public override string Problem1(string[] input, bool isTestInput)
  {
    return CalculateMostCalories(input).ToString();
  }

  public override string Problem2(string[] input, bool isTestInput)
  {
    return CalculateTopNCalories(input, 3).ToString();
  }

  public static int CalculateMostCalories(IEnumerable<string> input)
  {
    var maxCalories = 0;
    var curCalories = 0;

    foreach (var line in input)
    {
      if (string.IsNullOrWhiteSpace(line))
      {
        if (curCalories > maxCalories)
          maxCalories = curCalories;
        curCalories = 0;
      }
      else
      {
        var lineItemCalories = int.Parse(line);
        curCalories += lineItemCalories;
      }
    }

    if(curCalories > 0 && curCalories > maxCalories)
      maxCalories = curCalories;

    return maxCalories;
  }

  public static int CalculateTopNCalories(IEnumerable<string> input, int topNumber)
  {
    var allCalories = new List<int>();
    var curCalories = 0;

    foreach (var line in input)
    {
      if (string.IsNullOrWhiteSpace(line))
      {
        allCalories.Add(curCalories);
        curCalories = 0;
      }
      else
      {
        var lineItemCalories = int.Parse(line);
        curCalories += lineItemCalories;
      }
    }

    if(curCalories > 0)
      allCalories.Add(curCalories);

    return allCalories.OrderByDescending(x => x).Take(topNumber).Sum();
  }
}