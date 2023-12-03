using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day9;

public class Day9Problems : Problems
{
  protected override string TestInput => @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

  protected override int Day => 9;

  protected override string Problem1(string[] input, bool isTestInput)
  {
    var directions = ParseInputDirections(input);

    var currentHeadPosition = new Position(0, 0);
    var currentTailPosition = new Position(0, 0);
    var positionsVisitedByTail = new HashSet<Position>
    {
      currentTailPosition
    };

    foreach (var direction in directions)
    {
      currentHeadPosition = MoveHead(currentHeadPosition, direction);
      currentTailPosition = MoveTail(currentHeadPosition, currentTailPosition);
      positionsVisitedByTail.Add(currentTailPosition);
    }

    return positionsVisitedByTail.Count.ToString();
  }

  protected override string Problem2(string[] input, bool isTestInput)
  {
    var directions = ParseInputDirections(input);

    var currentHeadPosition = StartingPosition();
    var totalPositions = 9;
    var tailPositions = new Position[totalPositions];
    for (var i = 0; i < totalPositions; i++)
    {
      tailPositions[i] = StartingPosition();
    }
      
    var positionsVisitedByTail = new HashSet<Position>
    {
      StartingPosition()
    };

    foreach (var direction in directions)
    {
      currentHeadPosition = MoveHead(currentHeadPosition, direction);

      for (var i = 0; i < totalPositions; i++)
      {
        if (i == 0)
        {
          tailPositions[0] = MoveTail(currentHeadPosition, tailPositions[0]);
        }
        else
        {
          tailPositions[i] = MoveTail(tailPositions[i - 1], tailPositions[i]);
        }
      }

      positionsVisitedByTail.Add(tailPositions[^1]);
    }

    return positionsVisitedByTail.Count.ToString();
  }

  private static Position StartingPosition() => new(0, 0);

  private static Position MoveHead(Position currentHeadPos, Direction dir)
  {
    return dir switch
    {
      Direction.Up => new Position(currentHeadPos.X, currentHeadPos.Y + 1),
      Direction.Down => new Position(currentHeadPos.X, currentHeadPos.Y - 1),
      Direction.Left => new Position(currentHeadPos.X - 1, currentHeadPos.Y),
      Direction.Right => new Position(currentHeadPos.X + 1, currentHeadPos.Y),
    };
  }

  private static Position MoveTail(Position currentHeadPos, Position currentTailPos)
  {
    if ((currentTailPos.X >= currentHeadPos.X - 1) &&
        (currentTailPos.X <= currentHeadPos.X + 1) &&
        (currentTailPos.Y >= currentHeadPos.Y - 1) &&
        (currentTailPos.Y <= currentHeadPos.Y + 1))
    {
      return currentTailPos;
    }

    var newX = currentTailPos.X;
    var newY = currentTailPos.Y;

    if (currentTailPos.X < currentHeadPos.X)
    {
      newX++;
    }
    else if (currentTailPos.X > currentHeadPos.X)
    {
      newX--;
    }

    if (currentTailPos.Y < currentHeadPos.Y)
    {
      newY++;
    }
    else if (currentTailPos.Y > currentHeadPos.Y)
    {
      newY--;
    }

    return new Position(newX, newY);
  }

  private static List<Direction> ParseInputDirections(string[] input)
  {
    var directions = new List<Direction>();

    foreach (var s in input)
    {
      var parts = s.Split(' ');

      var direction = TranslateDirection(parts[0][0]);
      var count = int.Parse(parts[1]);
      for (var i = 0; i < count; i++)
      {
        directions.Add(direction);
      }
    }

    return directions;
  }

  private struct Position
  {
    public int X;
    public int Y;

    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }
  }

  private static Direction TranslateDirection(char dir)
  {
    return dir switch
    {
      'R' => Direction.Right,
      'L' => Direction.Left,
      'U' => Direction.Up,
      'D' => Direction.Down,
      _ => throw new ArgumentException()
    };
  }

  private enum Direction
  {
    Left,
    Right,
    Up,
    Down
  }
}