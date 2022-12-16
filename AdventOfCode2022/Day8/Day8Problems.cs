using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Util;

namespace AdventOfCode2022.Day8
{
  public class Day8Problems : Problems
  {
    public override string TestInput => @"30373
25512
65332
33549
35390";

    public override int Day => 8;

    public override string Problem1(string[] input, bool isTestInput)
    {
      var grid = ProcessInput(input);
      var visibleTrees = new HashSet<Tree>();

      for (var x = 0; x < grid[0].Length; x++)
      {
        SearchDown(grid, new Tree(x, 0, grid[0][x]), -1, visibleTrees);
        SearchUp(grid, new Tree(x, grid.Length - 1, grid[^1][x]), -1, visibleTrees);
      }

      for (var y = 0; y < grid.Length; y++)
      {
        SearchRight(grid, new Tree(0, y, grid[y][0]), -1, visibleTrees);
        SearchLeft(grid, new Tree(grid[0].Length - 1, y, grid[y][^1]), -1, visibleTrees);
      }

      return visibleTrees.Count().ToString();
    }

    public override string Problem2(string[] input, bool isTestInput)
    {
      var grid = ProcessInput(input);

      var maxScore = 0;

      for (var y = 0; y < grid.Length; y++)
      {
        for (var x = 0; x < grid[0].Length; x++)
        {
          var tree = new Tree(x, y, grid[y][x]);
          var curScore = CalculateScenicScore(grid, tree);
          if (curScore > maxScore)
            maxScore = curScore;
        }
      }

      return maxScore.ToString();
    }

    private static int CalculateScenicScore(int[][] grid, Tree tree)
    {
      var left = CalculateScoreLeft(grid, tree, tree.H, true);
      var right = CalculateScoreRight(grid, tree, tree.H, true);
      var up = CalculateScoreUp(grid, tree, tree.H, true);
      var down = CalculateScoreDown(grid, tree, tree.H, true);

      return left * right * up * down;
    }

    private static int CalculateScoreLeft(int[][] grid, Tree tree, int maxHeight, bool firstTree = false)
    {
      //check if on edge
      if (tree.X == 0)
        return 0;

      //check if is a blocker
      if (!firstTree && (tree.H >= maxHeight))
        return 0;

      return 1 + CalculateScoreLeft(grid, new Tree(tree.X - 1, tree.Y, grid[tree.Y][tree.X - 1]), maxHeight);
    }

    private static int CalculateScoreRight(int[][] grid, Tree tree, int maxHeight, bool firstTree = false)
    {
      //check if on edge
      if (tree.X == grid[0].Length - 1)
        return 0;

      //check if is a blocker
      if (!firstTree && (tree.H >= maxHeight))
        return 0;

      return 1 + CalculateScoreRight(grid, new Tree(tree.X + 1, tree.Y, grid[tree.Y][tree.X + 1]), maxHeight);
    }

    private static int CalculateScoreDown(int[][] grid, Tree tree, int maxHeight, bool firstTree = false)
    {
      //check if on edge
      if (tree.Y == grid.Length - 1)
        return 0;

      //check if is a blocker
      if (!firstTree && (tree.H >= maxHeight))
        return 0;

      return 1 + CalculateScoreDown(grid, new Tree(tree.X, tree.Y + 1, grid[tree.Y + 1][tree.X]), maxHeight);
    }

    private static int CalculateScoreUp(int[][] grid, Tree tree, int maxHeight, bool firstTree = false)
    {
      //check if on edge
      if (tree.Y == 0)
        return 0;

      //check if is a blocker
      if (!firstTree && (tree.H >= maxHeight))
        return 0;

      return 1 + CalculateScoreUp(grid, new Tree(tree.X, tree.Y - 1, grid[tree.Y - 1][tree.X]), maxHeight);
    }

    private static int[][] ProcessInput(string[] input)
    {
      var results = new int[input.Length][];
      var width = input[0].Length;

      int i = 0;
      foreach (var s in input)
      {
        results[i] = s.Select(c => int.Parse(c.ToString())).ToArray();

        i++;
      }

      return results;
    }

    private void SearchDown(int[][] grid, Tree currentTree, int currentTallest, HashSet<Tree> visibleTrees)
    {
      if (currentTree.H > currentTallest)
      {
        visibleTrees.Add(currentTree);
        currentTallest = currentTree.H;
      }

      if ((currentTallest == 9) || (currentTree.Y == grid.Length - 1))
      {
        return;
      }

      var nextTree = new Tree(currentTree.X, currentTree.Y + 1, grid[currentTree.Y + 1][currentTree.X]);
      SearchDown(grid, nextTree, currentTallest, visibleTrees);
    }

    private void SearchUp(int[][] grid, Tree currentTree, int currentTallest, HashSet<Tree> visibleTrees)
    {
      if (currentTree.H > currentTallest)
      {
        visibleTrees.Add(currentTree);
        currentTallest = currentTree.H;
      }

      if ((currentTallest == 9) || (currentTree.Y == 0))
      {
        return;
      }

      var nextTree = new Tree(currentTree.X, currentTree.Y - 1, grid[currentTree.Y - 1][currentTree.X]);
      SearchUp(grid, nextTree, currentTallest, visibleTrees);
    }

    private void SearchRight(int[][] grid, Tree currentTree, int currentTallest, HashSet<Tree> visibleTrees)
    {
      if (currentTree.H > currentTallest)
      {
        visibleTrees.Add(currentTree);
        currentTallest = currentTree.H;
      }

      if ((currentTallest == 9) || (currentTree.X == grid[currentTree.Y].Length - 1))
      {
        return;
      }

      var nextTree = new Tree(currentTree.X + 1, currentTree.Y, grid[currentTree.Y][currentTree.X + 1]);
      SearchRight(grid, nextTree, currentTallest, visibleTrees);
    }

    private void SearchLeft(int[][] grid, Tree currentTree, int currentTallest, HashSet<Tree> visibleTrees)
    {
      if (currentTree.H > currentTallest)
      {
        visibleTrees.Add(currentTree);
        currentTallest = currentTree.H;
      }

      if ((currentTallest == 9) || (currentTree.X == 0))
      {
        return;
      }

      var nextTree = new Tree(currentTree.X - 1, currentTree.Y, grid[currentTree.Y][currentTree.X - 1]);
      SearchLeft(grid, nextTree, currentTallest, visibleTrees);
    }

    private struct Tree
    {
      public int X;
      public int Y;
      public int H;

      public Tree(int x, int y, int h)
      {
        X = x;
        Y = y;
        H = h;
      }

      public override string ToString() => $"{X}:{Y}|{H}";
    }
  }
}
