using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day7;

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


  public override int Day => 7;

  private const int MaxDirSizeToCount = 100000;

  public override string Problem1(string[] input, bool isTestInput)
  {
    var rootDirectory = new Directory((Directory)null, "/");
    var currentDirectory = rootDirectory;
    var allDirectories = new List<Directory> { rootDirectory };

    foreach (var line in input.Select(l => l.Trim()))
    {
      if (line.StartsWith("$ "))
      {
        //handle a command -- either CD to root directory, CD to current parent directory, or CD to child directory
        var command = line.Substring(2);
        if (command.StartsWith("cd"))
        {
          var target = command.Substring(3);
          switch (target)
          {
            case "/":
              currentDirectory = rootDirectory;
              break;
            case "..":
              currentDirectory = currentDirectory.Parent;
              break;
            default:
              currentDirectory = currentDirectory.OpenChildDirectory(target);
              break;
          }
        }
        else //ls, do nothing
        {

        }
      }
      else
      {
        //handle a new item -- either "dir <dirname>" or "<filesize> <filename>"
        if (line.StartsWith("dir"))
        {
          var newDirName = line.Substring(4);
          var newDir = new Directory(currentDirectory, newDirName);
          allDirectories.Add(newDir);
          currentDirectory.AddChild(newDir);
        }
        else
        {
          var parts = line.Split(' ');
          var size = int.Parse(parts[0]);
          var name = parts[1];
          currentDirectory.AddChild(new File(currentDirectory, name, size));
        }
      }
    }

    //grotesquely inefficient but processing is cheap
    var countableDirectories = allDirectories.Where(d => d.CalculateSize() <= MaxDirSizeToCount);

    var total = countableDirectories.Select(d => d.CalculateSize()).Sum();

    return total.ToString();
  }

  public override string Problem2(string[] input, bool isTestInput)
  {
    var rootDirectory = new Directory((Directory)null, "/");
    var currentDirectory = rootDirectory;
    var allDirectories = new List<Directory> { rootDirectory };

    foreach (var line in input.Select(l => l.Trim()))
    {
      if (line.StartsWith("$ "))
      {
        //handle a command -- either CD to root directory, CD to current parent directory, or CD to child directory
        var command = line.Substring(2);
        if (command.StartsWith("cd"))
        {
          var target = command.Substring(3);
          switch (target)
          {
            case "/":
              currentDirectory = rootDirectory;
              break;
            case "..":
              currentDirectory = currentDirectory.Parent;
              break;
            default:
              currentDirectory = currentDirectory.OpenChildDirectory(target);
              break;
          }
        }
        else //ls, do nothing
        {

        }
      }
      else
      {
        //handle a new item -- either "dir <dirname>" or "<filesize> <filename>"
        if (line.StartsWith("dir"))
        {
          var newDirName = line.Substring(4);
          var newDir = new Directory(currentDirectory, newDirName);
          allDirectories.Add(newDir);
          currentDirectory.AddChild(newDir);
        }
        else
        {
          var parts = line.Split(' ');
          var size = int.Parse(parts[0]);
          var name = parts[1];
          currentDirectory.AddChild(new File(currentDirectory, name, size));
        }
      }
    }

    var totalFileSpace = 70000000;
    var requiredSpace = 30000000;

    var totalSpaceTaken = rootDirectory.CalculateSize();
    var totalSpaceAvailableForSystem = totalFileSpace - requiredSpace;

    var totalSpaceRequiredToBeFreed = totalSpaceTaken - totalSpaceAvailableForSystem;

    var directoryToDelete = rootDirectory;
    var currentSizeToDelete = totalSpaceTaken;
    foreach (var dir in allDirectories)
    {
      var dirSize = dir.CalculateSize();
      if (dirSize > totalSpaceRequiredToBeFreed && dirSize < currentSizeToDelete)
      {
        directoryToDelete = dir;
        currentSizeToDelete = dirSize;
      }
    }

    return currentSizeToDelete.ToString();
  }

  private abstract class Item
  {
    public Directory Parent;
    public string Name;

    public Item(Directory parent, string name)
    {
      Parent = parent;
      Name = name;
    }

    public abstract int CalculateSize();
  }

  private class Directory : Item
  {
    public List<Item> Children;

    public Directory(Directory parent, string name) : base(parent, name)
    {
      Children = new List<Item>();
    }

    public void AddChild(Item item)
    {
      Children.Add(item);
    }

    public override int CalculateSize()
    {
      return Children.Select(i => i.CalculateSize()).Sum();
    }

    public Directory OpenChildDirectory(string name)
    {
      return (Directory)Children.First(c => c.Name == name);
    }
  }

  private class File : Item
  {
    private readonly int Size;

    public File(Directory parent, string name, int size) : base(parent, name)
    {
      Size = size;
    }

    public override int CalculateSize() => Size;
  }
}