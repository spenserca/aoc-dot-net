using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day14Tests
{
    private readonly Day14 _underTest;

    public Day14Tests()
    {
        _underTest = new Day14();
    }

    [Fact(DisplayName =
        "determines how many units of sand will fall before endlessly falling into the abyss with test input")]
    public void DayFourteenPartOne_TestInput()
    {
        var input = new[]
        {
            "498,4 -> 498,6 -> 496,6",
            "503,4 -> 502,4 -> 502,9 -> 494,9",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(24);
    }
}