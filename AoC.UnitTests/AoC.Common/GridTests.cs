using System;
using AoC.Common;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace AoC.UnitTests.AoC.Common;

public class GridTests(ITestOutputHelper logger)
{
    [Fact(DisplayName = "displays the grid when calling the tostring method")]
    public void Test()
    {
        var input = new[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };
        var expected =
            $"....#.....{Environment.NewLine}.........#{Environment.NewLine}..........{Environment.NewLine}..#.......{Environment.NewLine}.......#..{Environment.NewLine}..........{Environment.NewLine}.#..^.....{Environment.NewLine}........#.{Environment.NewLine}#.........{Environment.NewLine}......#...";

        var actual = new Grid(input).ToString();

        actual.Should().Be(expected);
        logger.WriteLine(actual);
    }

    [Fact(DisplayName = "can get the coordinate with a specific value")]
    public void GetByValue()
    {
        var input = new[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };

        var actual = new Grid(input).GetByValue("^");

        using (new AssertionScope())
        {
            actual.Should().NotBeNull();
            actual!.X.Should().Be(4);
            actual.Y.Should().Be(6);
            actual.Value.Should().Be("^");
        }
    }

    [Theory(DisplayName = "can get the coordinates around the current coordinate when they have a value")]
    [InlineData(4, 1, ".", Direction.Up, 4 , 0, "#")]
    [InlineData(8, 6, ".", Direction.Down, 8 , 7, "#")]
    [InlineData(5, 6, ".", Direction.Left, 4 , 6, "^")]
    [InlineData(8, 1, ".", Direction.Right, 9 , 1, "#")]
    public void GetCoodinatesAroundWithValues(int currentX, int currentY, string currentValue, Direction direction, int nextX, int nextY, string nextValue)
    {
        var input = new[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };

        var actual = new Grid(input).GetValueInDirection(new GridCoordinate(currentX, currentY, currentValue), direction);

        using (new AssertionScope())
        {
            actual.Should().NotBeNull();
            actual!.X.Should().Be(nextX);
            actual.Y.Should().Be(nextY);
            actual.Value.Should().Be(nextValue);
        }
    }
    
    [Theory(DisplayName = "can get the coordinates around the current coordinate when they don't have a value")]
    [InlineData(4, 0, ".", Direction.Up)]
    [InlineData(8, 9, ".", Direction.Down)]
    [InlineData(0, 6, ".", Direction.Left)]
    [InlineData(9, 1, ".", Direction.Right)]
    public void GetCoordinatesAroundWithoutValues(int currentX, int currentY, string currentValue, Direction direction)
    {
        var input = new[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };

        var actual = new Grid(input).GetValueInDirection(new GridCoordinate(currentX, currentY, currentValue), direction);

        using (new AssertionScope())
        {
            actual.Should().BeNull();
        }
    }
}