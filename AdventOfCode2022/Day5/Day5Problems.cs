using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2022.Util;

namespace AdventOfCode2022.Day5
{
  public class Day5Problems : Problems
  {
    public override string TestInput => @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
    public override int Day => 5;

    private readonly Regex MovePattern = new("move (\\d+) from (\\d+) to (\\d+)", RegexOptions.Compiled);

    public override string Problem1(string[] input)
    {
      //first lines: use a stack to get the lines in the correct order when we encounter the line with numbers on it
      var settingUp = true;
      var moving = false;
      var setupLines = new Stack<string>();
      Stack<char>[] crateStacks = null;

      foreach (var line in input)
      {
        if (settingUp)
        {
          if (line.StartsWith('[') || line.StartsWith("  "))
          {
            setupLines.Push(line);
          }
          else
          {
            var nums = line.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
            var numberOfStacks = nums.Count();
            crateStacks = new Stack<char>[numberOfStacks];
            for (var i = 0; i < numberOfStacks; i++)
            {
              crateStacks[i] = new Stack<char>();
            }
            settingUp = false;
          }
        }
        else if (moving)
        {
          var match = MovePattern.Matches(line).First();
          var totalToMove = int.Parse(match.Groups[1].Value);
          var source = int.Parse(match.Groups[2].Value) - 1;
          var dest = int.Parse(match.Groups[3].Value) - 1;

          for (var i = 0; i < totalToMove; i++)
          {
            crateStacks[dest].Push(crateStacks[source].Pop());
          }

        }
        else //this will only get called on the blank line
        {
          while (setupLines.TryPop(out var curLine))
          {
            var chunks = curLine.Chunk(4).Select(s => new string(s));
            var i = 0;
            foreach (var chunk in chunks)
            {
              if (Regex.IsMatch(chunk, "\\[\\w\\]"))
                crateStacks[i].Push(chunk[1]);
              i++;
            }
          }

          moving = true;
        }
      }

      var result = new StringBuilder();
      foreach (var stack in crateStacks)
      {
        result.Append(stack.Pop());
      }

      return result.ToString();
    }

    public override string Problem2(string[] input)
    {
      var settingUp = true;
      var moving = false;
      var setupLines = new Stack<string>();
      Stack<char>[] crateStacks = null;

      foreach (var line in input)
      {
        if (settingUp)
        {
          if (line.StartsWith('[') || line.StartsWith("  "))
          {
            setupLines.Push(line);
          }
          else
          {
            var nums = line.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
            var numberOfStacks = nums.Count();
            crateStacks = new Stack<char>[numberOfStacks];
            for (var i = 0; i < numberOfStacks; i++)
            {
              crateStacks[i] = new Stack<char>();
            }
            settingUp = false;
          }
        }
        else if (moving)
        {
          var match = MovePattern.Matches(line).First();
          var totalToMove = int.Parse(match.Groups[1].Value);
          var source = int.Parse(match.Groups[2].Value) - 1;
          var dest = int.Parse(match.Groups[3].Value) - 1;
          var tempStack = new Stack<char>();

          for (var i = 0; i < totalToMove; i++)
          {
            tempStack.Push(crateStacks[source].Pop());
          }

          while (tempStack.TryPop(out var c))
          {
            crateStacks[dest].Push(c);
          }
        }
        else //this will only get called on the blank line
        {
          while (setupLines.TryPop(out var curLine))
          {
            var chunks = curLine.Chunk(4).Select(s => new string(s));
            var i = 0;
            foreach (var chunk in chunks)
            {
              if (Regex.IsMatch(chunk, "\\[\\w\\]"))
                crateStacks[i].Push(chunk[1]);
              i++;
            }
          }

          moving = true;
        }
      }

      var result = new StringBuilder();
      foreach (var stack in crateStacks)
      {
        result.Append(stack.Pop());
      }

      return result.ToString();
    }
  }
}
