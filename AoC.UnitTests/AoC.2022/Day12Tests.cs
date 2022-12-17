using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day12Tests
{
    private readonly Day12 _underTest;

    public Day12Tests()
    {
        _underTest = new Day12();
    }

    [Fact(DisplayName = "calculates the fewest steps required to get to the highest point with test input")]
    public void DayTwelvePartOne_TestInput()
    {
        var input = new[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(31);
    }
}