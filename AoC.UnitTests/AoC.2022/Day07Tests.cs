using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day07Tests
{
    private readonly Day07 _underTest;

    public Day07Tests()
    {
        _underTest = new Day07();
    }

    [Fact(DisplayName = "gets sum of sizes of all directories with size less than 10000 with test input")]
    public void DaySevenPartOne_TestInput()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(95437);
    }
}