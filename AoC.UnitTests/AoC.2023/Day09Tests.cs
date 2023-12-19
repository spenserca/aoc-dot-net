using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day09Tests : IDayPartOneTest
{
    private readonly Day09 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day09.txt";

    private readonly string[] _testInput =
    {
        "0 3 6 9 12 15",
        "1 3 6 10 15 21",
        "10 13 16 21 30 45",
    };

    [Fact(DisplayName = "calculates the sum of all extrapolated values with test input")]
    public void PartOne_TestInput()
    {
        var actual = _underTest.PartOne(_testInput);

        actual.Should().Be(114);
    }

    public void PartOne_ActualInput()
    {
        throw new System.NotImplementedException();
    }
}