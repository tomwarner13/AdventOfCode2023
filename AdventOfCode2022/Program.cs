// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.DayOne;
using AdventOfCode2022.DayTwo;

//var inputBasic = @"1000
//2000
//3000

//4000

//5000
//6000

//7000
//8000
//9000

//10000";


//Console.WriteLine(DayOneProblems.CalculateTopNCalories(inputBasic.Split('\n'), 3));
//Console.WriteLine(DayOneProblems.CalculateTopNCaloriesFromInputFile("DayOne\\D1P1.txt", 3));

var input = @"A Y
B X
C Z";

Console.WriteLine(DayTwoProblems.CalculateRpsScore(input.Split('\n')));
Console.WriteLine(DayTwoProblems.CalculateRpsScoreFromInputFile("DayTwo\\D2.txt"));


Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructions(input.Split('\n')));
Console.WriteLine(DayTwoProblems.CalculateRpsScoreWithInstructionsFromInputFile("DayTwo\\D2.txt"));