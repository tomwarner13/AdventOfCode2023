﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Util
{
  public abstract class Problems
  {
    public abstract string TestInput { get; }

    public abstract string FullInputFilePath { get; }

    public abstract string Problem1(string[] input);
    public abstract string Problem2(string[] input);

    public string Problem1TestInput()
    {
      var lines = TestInput.Split('\n');
      return Problem1(lines);
    }

    public string Problem2TestInput()
    {
      var lines = TestInput.Split('\n');
      return Problem2(lines);
    }

    public string Problem1FullInput()
    {
      var lines = File.ReadAllLines(FullInputFilePath);
      return Problem1(lines);
    }

    public string Problem2FullInput()
    {
      var lines = File.ReadAllLines(FullInputFilePath);
      return Problem2(lines);
    }
  }
}
