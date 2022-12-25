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

    [Fact(DisplayName = "calculates the fewest steps required to get to the highest point with test input")]
    public void DayTwelvePartOne_TestInput()
    {
        var actual = _underTest.PartOne(TestInput);

        actual.Should().Be(31);
    }

    [Theory(DisplayName = "gets the coordinate position of the value in the test input")]
    [InlineData('S', 0, 0, 0)]
    [InlineData('E', 5, 2, 25)]
    public void GetPositionOfValue_ReturnsCorrectPositionOfValueFromTestInput(char value, int x, int y, int z)
    {
        var actual = TestInput.GetPositionOfValue(value, z);

        actual.X.Should().Be(x);
        actual.Y.Should().Be(y);
        actual.Z.Should().Be(z);
    }
    
    [Theory(DisplayName = "gets the coordinate position of the value in the actual input")]
    [InlineData('S', 0, 20, 0)]
    [InlineData('E', 119, 20, 25)]
    public void GetPositionOfValue_ReturnsCorrectPositionOfValueFromActualInput(char value, int x, int y, int z)
    {
        var actual = ActualInput.GetPositionOfValue(value, z);

        actual.X.Should().Be(x);
        actual.Y.Should().Be(y);
        actual.Z.Should().Be(z);
    }

    [Theory(DisplayName = "gets the coordinates surrounding the given coordinate in the first row")]
    [InlineData(4, 0, 0)]
    public void GetSurroundingCoordinates_CoordinateInFirstRow_GetsSurroundingCoordinates(int x, int y, int z)
    {
        
    }
}   