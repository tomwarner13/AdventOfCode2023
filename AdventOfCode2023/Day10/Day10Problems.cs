using System.Text;
using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day10
{
  public class Day10Problems : Problems
  {
    public override string TestInput => @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

    public override int Day => 10;

    public override string Problem1(string[] input, bool isTestInput)
    {
      var cpu = new Cpu();

      foreach (var line in input)
      {
        if (line == "noop")
        {
          cpu.NoOp();
        }
        else
        {
          var parts = line.Split(' ');
          var x = int.Parse(parts[1]);
          cpu.AddX(x);
        }
      }

      return cpu.GetSignal().ToString();
    }

    public override string Problem2(string[] input, bool isTestInput)
    {
      var cpu = new Cpu();

      foreach (var line in input)
      {
        if (line == "noop")
        {
          cpu.NoOp();
        }
        else
        {
          var parts = line.Split(' ');
          var x = int.Parse(parts[1]);
          cpu.AddX(x);
        }
      }

      return cpu.GetDrawing();
    }

    private class Cpu
    {
      private int _cycleCount;
      private int _registerX;
      private int _signal;
      private StringBuilder _crt; //in OUR CHILDREN'S SCHOOLS !?!?!?!?!

      public Cpu()
      {
        _cycleCount = 0;
        _registerX = 1;
        _signal = 0;
        _crt = new StringBuilder();
      }

      public int GetSignal() => _signal;

      public string GetDrawing() => _crt.ToString();

      public void NoOp()
      {
        AdvanceCycle();
      }

      public void AddX(int x)
      {
        AdvanceCycle();
        AdvanceCycle();
        _registerX += x;
      }

      private void AdvanceCycle()
      {
        DrawPixel();

        _cycleCount++;
        if (ShouldTrackSignal())
          _signal += _registerX * _cycleCount;

        if (_cycleCount % 40 == 0)
          _crt.AppendLine();
      }

      private void DrawPixel()
      {
        char pixel;
        var horizontalPos = _cycleCount % 40;
        if ((horizontalPos >= _registerX - 1) && (horizontalPos <= _registerX + 1))
        {
          pixel = '#';
        }
        else
        {
          pixel = '.';
        }

        _crt.Append(pixel);
      }

      private bool ShouldTrackSignal()
      {
        return _cycleCount % 40 == 20;
      }
    }
  }
}
