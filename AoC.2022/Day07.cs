using AoC.Common;

namespace AoC._2022;

public class Day07 : IDay
{
    public string Title => "--- Day 7: No Space Left On Device ---";

    public object PartOne(string[] input)
    {
        var currentDirectory = string.Empty;
        var directories = new Dictionary<string, Directory>();

        foreach (var terminalOutput in input)
        {
            if (IsChangeDirectoryCommand(terminalOutput) && !IsDotDotCommand(terminalOutput))
            {
                currentDirectory = terminalOutput.Split(' ')[2];
                if (!directories.ContainsKey(currentDirectory))
                {
                    directories.Add(currentDirectory, new Directory());
                }
            }

            if (IsDirectory(terminalOutput))
            {
                var subDirectory = terminalOutput.Split(' ')[1];
                if (!directories.ContainsKey(subDirectory))
                {
                    directories.Add(subDirectory, new Directory());
                }

                directories[currentDirectory].SubDirectories.Add(subDirectory);
            }

            if (IsFile(terminalOutput, out var size))
            {
                directories[currentDirectory].FileSize += size;
            }
        }

        return directories.Select(d =>
        {
            var directorySize = d.Value.GetDirectorySize(directories);

            return directorySize <= 100000 ? directorySize : 0;
        }).Sum();
    }

    private static bool IsDotDotCommand(string terminalOutput)
    {
        return terminalOutput == "$ cd ..";
    }

    private bool IsFile(string terminalOutput, out int size)
    {
        var split = terminalOutput.Split(' ');
        return int.TryParse(split[0], out size);
    }

    private bool IsDirectory(string terminalOutput)
    {
        return terminalOutput.StartsWith("dir ");
    }

    private bool IsChangeDirectoryCommand(string terminalOutput)
    {
        return terminalOutput.StartsWith("$ cd");
    }

    private class Directory
    {
        public List<string> SubDirectories { get; } = new();
        public int FileSize { get; set; } = 0;

        public int GetDirectorySize(IReadOnlyDictionary<string, Directory> directories)
        {
            if (FileSize > 100000)
            {
                return 0;
            }

            if (!SubDirectories.Any())
            {
                return FileSize;
            }

            return FileSize + SubDirectories.Select(sd => directories[sd].GetDirectorySize(directories)).Sum();
        }
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}