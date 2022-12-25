using AoC.Common;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AoC.UnitTests.Common;

public class StringArrayExtensionsTests
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

    #region GetPositionOfValue

    [Theory(DisplayName = "gets the coordinate position of the value in the actual input")]
    [InlineData('S', 0, 20, 0, false)]
    [InlineData('E', 119, 20, 25, false)]
    [InlineData('S', 0, 0, 0, true)]
    [InlineData('E', 5, 2, 25, true)]
    public void GetPositionOfValue_ReturnsCorrectPositionOfValueFromActualInput(char value, int x, int y, int z,
        bool useTestInput)
    {
        var actual = useTestInput
            ? TestInput.GetPositionOfValue(value, z)
            : ActualInput.GetPositionOfValue(value, z);

        actual.X.Should().Be(x);
        actual.Y.Should().Be(y);
        actual.Z.Should().Be(z);
    }

    #endregion

    #region GetSurroundingCoordinates

    [Fact(DisplayName = "when point is top left corner, has 2 surrounding values")]
    public void GetSurroundingCoordinates_TopLeftCorner_ReturnsTwoValidCoordinates()
    {
        var coordinate = new Coordinate(0, 0);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(2);
            actual.Should().Contain(new Coordinate(0, 1));
            actual.Should().Contain(new Coordinate(1, 0));
        }
    }

    [Fact(DisplayName = "when point is top right corner, has 2 surrounding values")]
    public void GetSurroundingCoordinates_TopRightCorner_ReturnsTwoValidCoordinates()
    {
        var coordinate = new Coordinate(7, 0);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(2);
            actual.Should().Contain(new Coordinate(7, 1));
            actual.Should().Contain(new Coordinate(6, 0));
        }
    }

    [Fact(DisplayName = "when point is bottom left corner, has 2 surrounding values")]
    public void GetSurroundingCoordinates_BottomLeftCorner_ReturnsTwoValidCoordinates()
    {
        var coordinate = new Coordinate(0, 4);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(2);
            actual.Should().Contain(new Coordinate(0, 3));
            actual.Should().Contain(new Coordinate(1, 4));
        }
    }

    [Fact(DisplayName = "when point is bottom right corner, has 2 surrounding values")]
    public void GetSurroundingCoordinates_BottomRightCorner_ReturnsTwoValidCoordinates()
    {
        var coordinate = new Coordinate(7, 4);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(2);
            actual.Should().Contain(new Coordinate(7, 3));
            actual.Should().Contain(new Coordinate(6, 4));
        }
    }
    
    [Fact(DisplayName = "when point is in the top row (not on a corner), has 3 surrounding values")]
    public void GetSurroundingCoordinates_TopRow_ReturnsThreeCoordinates()
    {
        var coordinate = new Coordinate(4, 0);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(3);
            actual.Should().Contain(new Coordinate(5, 0));
            actual.Should().Contain(new Coordinate(3, 0));
            actual.Should().Contain(new Coordinate(4, 1));
        }
    }
    
    [Fact(DisplayName = "when point is in the bottom row (not on a corner), has 3 surrounding values")]
    public void GetSurroundingCoordinates_BottomRow_ReturnsThreeCoordinates()
    {
        var coordinate = new Coordinate(4, 4);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(3);
            actual.Should().Contain(new Coordinate(5, 4));
            actual.Should().Contain(new Coordinate(3, 4));
            actual.Should().Contain(new Coordinate(4, 3));
        }
    }
    
    [Fact(DisplayName = "when point is on the left edge (not on a corner), has 3 surrounding values")]
    public void GetSurroundingCoordinates_LeftEdge_ReturnsThreeCoordinates()
    {
        var coordinate = new Coordinate(0, 2);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(3);
            actual.Should().Contain(new Coordinate(0, 1));
            actual.Should().Contain(new Coordinate(0, 3));
            actual.Should().Contain(new Coordinate(1, 2));
        }
    }
    
    [Fact(DisplayName = "when point is on the right edge (not on a corner), has 3 surrounding values")]
    public void GetSurroundingCoordinates_RightEdge_ReturnsThreeCoordinates()
    {
        var coordinate = new Coordinate(7, 2);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(3);
            actual.Should().Contain(new Coordinate(7, 1));
            actual.Should().Contain(new Coordinate(7, 3));
            actual.Should().Contain(new Coordinate(6, 2));
        }
    }
    
    [Fact(DisplayName = "when point is not on the edge, has 4 surrounding values")]
    public void GetSurroundingCoordinates_NotOnEdge_ReturnsThreeCoordinates()
    {
        var coordinate = new Coordinate(4, 3);

        var actual = TestInput.GetSurroundingCoordinates(coordinate);

        using (new AssertionScope())
        {
            actual.Count.Should().Be(4);
            actual.Should().Contain(new Coordinate(3, 3));
            actual.Should().Contain(new Coordinate(5, 3));
            actual.Should().Contain(new Coordinate(4, 4));
            actual.Should().Contain(new Coordinate(4, 2));
        }
    }

    #endregion
}