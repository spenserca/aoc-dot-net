using AoC._2022;
using AoC.Common;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day12Tests
{
    private readonly Day12 _underTest;

    private static readonly string[] TestInput =
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi",
    };

    private static readonly string[] ActualInput = FileReader.ReadAllLines(@"AoC.2022/Data/Day12.txt");

    public Day12Tests()
    {
        _underTest = new Day12();
    }

    [Fact(DisplayName = "calculates the fewest steps required to get to the highest point with test input", Skip = "true")]
    public void DayTwelvePartOne_TestInput()
    {
        var actual = _underTest.PartOne(TestInput);

        actual.Should().Be(31);
    }
}   