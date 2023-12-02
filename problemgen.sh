#!/bin/sh

DAY=$1

cat << EOF
using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day$1
{
  public class Day$1Problems : Problems
  {
    public override string TestInput => @"";

    public override int Day => $1;

    public override string Problem1(string[] input)
    {
      throw new NotImplementedException();
    }

    public override string Problem2(string[] input)
    {    
      throw new NotImplementedException();
    }
  }
}
EOF
