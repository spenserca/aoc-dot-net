using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day09Tests
{
    private readonly Day09 _underTest;

    public Day09Tests()
    {
        _underTest = new Day09();
    }

    [Fact(
        DisplayName = "gets the number of locations the tail visited at least once with test input"
    )]
    public void DayNinePartOne_TestInput()
    {
        var input = new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(13);
    }

    [Fact(
        DisplayName = "gets the number of locations the tail visited at least once with actual input"
    )]
    public void DayNinePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day09.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(6311);
    }

    [Fact(
        DisplayName = "gets the number of locations the tail visited at least once (with 10 knots) with test input"
    )]
    public void DayNinePartTwo_TestInput()
    {
        var input = new[] { "R 5", "U 8", "L 8", "D 3", "R 17", "D 10", "L 25", "U 20", };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(36);
    }

    [Fact(
        DisplayName = "gets the number of locations the tail visited at least once (with 10 knots) with actual input"
    )]
    public void DayNinePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day09.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2482);
    }
}
