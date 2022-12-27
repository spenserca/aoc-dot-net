using AoC.Common;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.Common;

public class CoordinateExtensionsTests
{
    private static readonly string[] TestInput =
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi",
    };

    private static readonly string[] ActualInput = FileReader.ReadAllLines(@"AoC.2022/Data/Day12.txt");

    #region IsAdjacentTo

    [Theory(DisplayName = "when coordinate is adjacent, returns true otherwise returns false")]
    [InlineData(0, 0, 0, 1, true)]
    public void IsAdjacentTo(int sourceX, int sourceY, int targetX, int targetY, bool isAdjacent)
    {
        var source = new Coordinate(sourceX, sourceY);
        var target = new Coordinate(targetX, targetY);

        source.IsAdjacentTo(target).Should().Be(isAdjacent);
    }

    #endregion

    #region IncrementY

    [Theory(DisplayName = "creates a new coordinate with the incremented Y value")]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, 5)]
    public void IncrementY(int x, int y, int incrementBy)
    {
        var expectedY = y + incrementBy;
        var source = new Coordinate(x, y);

        var actual = source.IncrementY(incrementBy);

        actual.Should().Be(new Coordinate(0, expectedY));
    }

    #endregion

    #region DecrementY

    [Theory(DisplayName = "creates a new coordinate with the decremented Y value")]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, 5)]
    public void DecrementY(int x, int y, int decrementBy)
    {
        var source = new Coordinate(x, y);
        var expectedY = source.Y - decrementBy;

        var actual = source.DecrementY(decrementBy);

        actual.Should().Be(new Coordinate(0, expectedY));
    }

    #endregion

    #region IncrementX

    [Theory(DisplayName = "creates a new coordinate with the incremented X value")]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, -1)]
    public void IncrementX(int x, int y, int expectedX)
    {
        var source = new Coordinate(x, y);
        var incrementBy = expectedX - source.X;

        var actual = source.IncrementX(incrementBy);

        actual.Should().Be(new Coordinate(expectedX, y));
    }

    #endregion

    #region DecrementX

    [Theory(DisplayName = "creates a new coordinate with the decremented X value")]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, -1)]
    public void DecrementX(int x, int y, int expectedX)
    {
        var source = new Coordinate(x, y);
        var decrementBy = source.X - expectedX;

        var actual = source.DecrementX(decrementBy);

        actual.Should().Be(new Coordinate(expectedX, y));
    }

    #endregion
}