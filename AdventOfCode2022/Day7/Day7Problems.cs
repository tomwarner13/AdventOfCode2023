using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2022.Util;

namespace AdventOfCode2022.Day7
{
  public class Day7Problems : Problems
  {
    public override string TestInput => @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    public override string FullInputFilePath => $"Day{Day}\\D{Day}.txt";
    public const int Day = 7;

    private const int MaxDirSizeToCount = 100000;

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
