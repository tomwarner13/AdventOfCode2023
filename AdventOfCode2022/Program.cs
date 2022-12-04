// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.DayThree;


var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

//Console.WriteLine(DayThreeProblems.CalculatePackPriorityScore(input.Split('\n')));
//Console.WriteLine(DayThreeProblems.CalculatePackPriorityScoreFromInputFile("DayThree\\D3.txt"));


Console.WriteLine(DayThreeProblems.CalculateBadgePriorityScore(input.Split('\n')));
Console.WriteLine(DayThreeProblems.CalculateBadgePriorityScoreFromInputFile("DayThree\\D3.txt"));

//Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructions(input.Split('\n')));
//Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructionsFromInputFile("DayTwo\\D2.txt"));