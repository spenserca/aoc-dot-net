using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day06Tests : IDayPartOneTest, IDayPartTwoTest
{
    private readonly Day06 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day06.txt";

    private readonly string[] _testInput = { "Time:      7  15   30", "Distance:  9  40  200" };

    [Fact(
        DisplayName = "gets the multiplied value of all ways to win for all races with test input"
    )]
    public void PartOne_TestInput()
    {
        var actual = _underTest.PartOne(_testInput);

        actual.Should().Be(288);
    }

    [Fact(
        DisplayName = "gets the multiplied value of all ways to win for all races with actual input"
    )]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(3316275);
    }

    [Fact(DisplayName = "gets the number of ways to win for the race with test input")]
    public void PartTwo_TestInput()
    {
        var actual = _underTest.PartTwo(_testInput);

        actual.Should().Be(71503);
    }

    [Fact(DisplayName = "gets the number of ways to win for the race with actual input")]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(27102791);
    }
}
