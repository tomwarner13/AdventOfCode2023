// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.DayFour;


var input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

//Console.WriteLine(DayThreeProblems.CalculatePackPriorityScore(input.Split('\n')));
//Console.WriteLine(DayThreeProblems.CalculatePackPriorityScoreFromInputFile("DayThree\\D3.txt"));


Console.WriteLine(DayFourProblems.CalculateDuplicateAssignmentScore(input.Split('\n')));
Console.WriteLine(DayFourProblems.CalculateDuplicateAssignmentScoreFromInputFile("DayFour\\D4.txt"));


Console.WriteLine(DayFourProblems.CalculateOverlapAssignmentScore(input.Split('\n')));
Console.WriteLine(DayFourProblems.CalculateOverlapAssignmentScoreFromInputFile("DayFour\\D4.txt"));

//Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructions(input.Split('\n')));
//Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructionsFromInputFile("DayTwo\\D2.txt"));