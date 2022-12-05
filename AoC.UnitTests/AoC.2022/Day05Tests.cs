using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day05Tests
{
    private readonly Day05 _underTest;
    private const string TestFilePath = @"AoC.2022/Data/Day05.txt";

    public Day05Tests()
    {
        _underTest = new Day05();
    }

    [Fact(DisplayName = "determines which crates are on top after rearrangement with test input")]
    public void DayFivePartOne_TestInput()
    {
        var input = new[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be("CMZ");
    }

    [Fact(DisplayName = "determines which crates are on top after rearrangement with actual input")]
    public void DayFivePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestFilePath);

        var actual = _underTest.PartOne(input);

        actual.Should().Be("PSNRGBTFT");
    }

    [Fact(DisplayName = "determines which crates are on top after rearrangement using the CrateMover 9001 with test input")]
    public void DayFivePartTwo_TestInput()
    {
        var input = new[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be("MCD");
    }

    [Fact(DisplayName = "determines which crates are on top after rearrangement using the CrateMover 9001 with actual input")]
    public void DayFivePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestFilePath);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be("BNTZFPMMW");
    }
}