using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Util
{
  public struct GridPoint : IEquatable<GridPoint>
  {
    public readonly int X;
    public readonly int Y;

    public GridPoint(int x, int y)
    {
      X = x;
      Y = y;
    }

    public bool Equals(GridPoint other)
    {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
      return obj is GridPoint other && Equals(other);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(X, Y);
    }

    public static bool operator ==(GridPoint a, GridPoint b)
    {
      return a.Equals(b);
    }

    public static bool operator !=(GridPoint a, GridPoint b)
    {
      return !a.Equals(b);
    }

    public override string ToString() => $"{X}:{Y}";
  }
}
