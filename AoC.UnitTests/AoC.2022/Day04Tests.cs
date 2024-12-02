using System.IO;
using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day04Tests
{
    private readonly Day04 _underTest;
    private const string TestDataFile = @"AoC.2022/Data/Day04.txt";

    public Day04Tests()
    {
        _underTest = new Day04();
    }

    [Fact(
        DisplayName = "calculates the number of pairs where one range contains the other with test input"
    )]
    public void DayFourPartOne_TestInput()
    {
        var input = new[] { "2-4,6-8", "2-3,4-5", "5-7,7-9", "2-8,3-7", "6-6,4-6", "2-6,4-8", };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(2);
    }

    [Fact(
        DisplayName = "calculates the number of pairs where one range contains the other with actual input",
        Skip = "input file not included"
    )]
    public void DayFourPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(526);
    }

    [Fact(
        DisplayName = "calculates the number of pairs where one range contains any part of the other with test input"
    )]
    public void DayFourPartTwo_TestInput()
    {
        var input = new[] { "2-4,6-8", "2-3,4-5", "5-7,7-9", "2-8,3-7", "6-6,4-6", "2-6,4-8", };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(4);
    }

    [Fact(
        DisplayName = "calculates the number of pairs where one range contains any part of the other with actual input",
        Skip = "input file not included"
    )]
    public void DayFourPartTwo_ActualInput()
    {
        var input = File.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(886);
    }
}
