using AoC.Common;

namespace AoC._2022;

public class Day07 : IDay
{
    public string Title => "--- Day 7: No Space Left On Device ---";

    private static readonly Directory Root = new("/");
    private Directory _currentWorkingDirectory = Root;

    public object PartOne(string[] input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            var terminalOutput = input[i];
            var args = new Args(terminalOutput);

            if (args.IsCommand())
            {
                if (args.IsChangeDirectoryCommand())
                {
                    var changeDirectoryCommand = args.ToChangeDirectoryCommand;
                    if (changeDirectoryCommand.GetDirectoryToChangeTo() == "/")
                    {
                        _currentWorkingDirectory = Root;
                    }
                    else if (changeDirectoryCommand.IsDotDotCommand())
                    {
                        _currentWorkingDirectory = _currentWorkingDirectory.Parent;
                    }
                    else
                    {
                        _currentWorkingDirectory =
                            _currentWorkingDirectory.GetDirectory(changeDirectoryCommand
                                .GetDirectoryToChangeTo());
                    }
                } else if (args.IsListCommand())
                {
                    var operations = new List<string>();

                    for (var j = i + 1; j < input.Length; j++)
                    {
                        var operation = input[j];
                        if (operation.StartsWith("$")) break;

                        operations.Add(operation);
                    }

                    ExecuteList(operations);
                }
            }
        }

        return Root.TotalSizeUnderThreshold;
    }

    private void ExecuteList(List<string> operations)
    {
        foreach (var operation in operations)
        {
            var args = new Args(operation);

            if (args.IsDirectoryListing())
            {
                var dir = args.ToDirectoryListing;
                _currentWorkingDirectory.SubDirectories.Add(new Directory(dir.DirectoryName)
                {
                    Parent = _currentWorkingDirectory
                });
            }
            else
            {
                var file = args.ToFileListing;
                _currentWorkingDirectory.SizeOfAllFiles += file.Size;
            }
        }
    }

    private class Args
    {
        protected readonly List<string> _args = new();

        public Args(string terminalOutput)
        {
            _args.AddRange(terminalOutput.Split(' '));
        }

        public bool IsCommand()
        {
            return _args.Contains("$");
        }

        public bool IsChangeDirectoryCommand()
        {
            return IsCommand() && _args.Contains("cd");
        }

        public ChangeDirectoryCommand ToChangeDirectoryCommand => new(_args);
        public DirectoryListing ToDirectoryListing => new(_args);
        public FileListing ToFileListing => new(_args);

        public bool IsFileListing()
        {
            return !IsCommand() && !_args.Contains("dir");
        }

        public bool IsDirectoryListing()
        {
            return !IsCommand() && _args.Contains("dir");
        }

        public bool IsListCommand()
        {
            return IsCommand() && _args.Contains("ls");
        }
    }

    private class DirectoryListing
    {
        private readonly List<string> _args;

        public DirectoryListing(List<string> args)
        {
            _args = args;
        }

        public string DirectoryName => _args.Single(a => a != "dir");
    }

    private class FileListing
    {
        private readonly List<string> _args;

        public FileListing(List<string> args)
        {
            _args = args;
        }

        public int Size => int.Parse(_args.FirstOrDefault());
    }

    private class ChangeDirectoryCommand
    {
        private readonly List<string> _args;

        public ChangeDirectoryCommand(List<string> args)
        {
            _args = args;
        }

        public bool IsDotDotCommand()
        {
            return _args.Contains("..");
        }

        public string GetDirectoryToChangeTo()
        {
            return _args.Single(a => a != "$" && a != "cd");
        }
    }

    private class Directory
    {
        public string Name { get; }

        public Directory(string name)
        {
            Name = name;
        }

        public List<Directory> SubDirectories { get; } = new();
        public int SizeOfAllFiles { get; set; } = 0;
        public Directory Parent { get; set; }

        private bool HasOnlyFiles => !SubDirectories.Any();
        public int TotalSizeUnderThreshold => CalculateDirectorySizeIfUnderThreshold();

        private int CalculateDirectorySizeIfUnderThreshold()
        {
            if (HasOnlyFiles) return SizeOfAllFiles <= 100000 ? SizeOfAllFiles : 0;

            var totalSize = SizeOfAllFiles <= 100000 ? SizeOfAllFiles : 0;

            foreach (var directory in SubDirectories)
            {
                var directorySize = directory.CalculateDirectorySizeIfUnderThreshold();
                totalSize += directorySize;
            }

            return totalSize;
        }

        public Directory GetDirectory(string directoryToChangeTo)
        {
            return SubDirectories.Single(sd => sd.Name == directoryToChangeTo);
        }
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}