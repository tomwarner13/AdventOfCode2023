using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Util;

namespace AdventOfCode2022.DayOne;

public static class DayOneProblems
{
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

  public static int CalculateMostCaloriesFromInputFile(string filepath)
  {
    var input = File.ReadAllLines(filepath);
    return CalculateMostCalories(input);
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

  public static int CalculateTopNCaloriesFromInputFile(string filepath, int topN)
  {
    var input = File.ReadAllLines(filepath);
    return CalculateTopNCalories(input, topN);
  }
}