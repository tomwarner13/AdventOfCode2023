using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day2
{
  public class Day2Problems : Problems
  {
    public override string TestInput => @"A Y
B X
C Z";

    public override int Day => 2;
    public override string Problem1(string[] input, bool isTestInput)
    {
      return CalculateRpsScore(input).ToString();
    }

    public override string Problem2(string[] input, bool isTestInput)
    {
      return CalculateRpsScoreWithInstructions(input).ToString();
    }


    private static int CalculateRpsScore(IEnumerable<string> input)
    {
      var total = 0;
      foreach (var line in input)
      {
        var (opponent, own) = ParseBasicInput(line);
        total += CalculateGameScore(opponent, own);
      }

      return total;
    }

    private static int CalculateRpsScoreWithInstructions(IEnumerable<string> input)
    {
      var total = 0;
      foreach (var line in input)
      {
        var (opponent, own) = ParseDependentInput(line);
        total += CalculateGameScore(opponent, own);
      }

      return total;
    }

    private static (RPS Opponent, RPS Own) ParseBasicInput(string line)
    {
      return (TranslateInput(line[0]), TranslateInput(line[2]));
    }

    private static (RPS Opponent, RPS Own) ParseDependentInput(string line)
    {
      var opponent = TranslateInput(line[0]);

      RPS own;
      var instruction = line[2];
      switch (instruction)
      {
        case 'X':
          own = GetLosingMove(opponent);
          break;
        case 'Y':
          own = opponent;
          break;
        case 'Z':
          own = GetWinningMove(opponent);
          break;
        default:
          throw new ArgumentException();
      }

      return (opponent, own);
    }

    private static RPS TranslateInput(char input)
    {
      return input switch
      {
        'A' or 'X' => RPS.Rock,
        'B' or 'Y' => RPS.Paper,
        'C' or 'Z' => RPS.Scissors,
        _ => throw new ArgumentException($"invalid input: '{input}'"),
      };
    }

    private static RPS GetLosingMove(RPS opponent)
    {
      return opponent switch
      {
        RPS.Paper => RPS.Rock,
        RPS.Rock => RPS.Scissors,
        RPS.Scissors => RPS.Paper,
        _ => throw new ArgumentException($"invalid input: '{opponent}'"),
      };
    }

    private static RPS GetWinningMove(RPS opponent)
    {
      return opponent switch
      {
        RPS.Paper => RPS.Scissors,
        RPS.Rock => RPS.Paper,
        RPS.Scissors => RPS.Rock,
        _ => throw new ArgumentException($"invalid input: '{opponent}'"),
      };
    }

    private static int CalculateGameScore(RPS opponentMove, RPS ownMove)
    {
      var total = (int)ownMove;

      if (opponentMove == ownMove)
      {
        total += 3; //draw
      }
      else
      {
        if(
          (opponentMove == RPS.Rock && ownMove == RPS.Paper) || //paper beats rock
          (opponentMove == RPS.Paper && ownMove == RPS.Scissors) || //scissors beats paper
          (opponentMove == RPS.Scissors && ownMove == RPS.Rock)) //rock beats scissors
        {
          total += 6; //victory
        }
      }

      return total;
    }

    private enum RPS
    {
      Rock = 1,
      Paper = 2,
      Scissors = 3
    }
  }
}
