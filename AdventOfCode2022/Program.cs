// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Day1;
using AdventOfCode2022.Day2;
using AdventOfCode2022.Day3;
//using AdventOfCode2022.Day4;
using AdventOfCode2022.Day5;
using AdventOfCode2022.Day6;
using AdventOfCode2022.Day7;
using AdventOfCode2022.Day8;
using AdventOfCode2022.Day9;
using AdventOfCode2022.Day10;
using AdventOfCode2022.Day11;
using AdventOfCode2022.Day12;
using AdventOfCode2022.Day13;
using AdventOfCode2022.Day14;
using AdventOfCode2022.Day15;
using AdventOfCode2022.Day16;
using AdventOfCode2022.Day17;
using AdventOfCode2022.Day18;
using AdventOfCode2022.Day19;
using AdventOfCode2022.Day20;
using AdventOfCode2022.Day21;
using AdventOfCode2022.Day22;
using AdventOfCode2022.Day23;
using AdventOfCode2022.Day24;
using AdventOfCode2022.Day25;
using AdventOfCode2022.Util;

DoAllProblems(new Day3Problems());

var problems = new Day13Problems();
DoAllProblems(problems);



void DoAllProblems(Problems probs)
{
  TryPrintResult(probs.Problem1TestInput, "Problem 1 Test Input");
  TryPrintResult(probs.Problem1FullInput, "Problem 1 Full Input");
  TryPrintResult(probs.Problem2TestInput, "Problem 2 Test Input");
  TryPrintResult(probs.Problem2FullInput, "Problem 2 Full Input");
}

void TryPrintResult(Func<string> attempter, string description)
{
  try
  {
    var result = attempter();

    Console.WriteLine($"{description}:");
    Console.WriteLine(result);
  }
  catch (NotImplementedException)
  {
    Console.WriteLine($"{description} not implemented");
  }
  catch(Exception e)
  {
    Console.WriteLine($"{description} failed:");
    Console.WriteLine(e);
  }


  Console.WriteLine();
}