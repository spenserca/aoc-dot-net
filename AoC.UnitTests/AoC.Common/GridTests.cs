using System;
using AoC.Common;
using Xunit.Abstractions;

namespace AoC.UnitTests.AoC.Common;

public class GridTests(ITestOutputHelper logger)
{
    [Fact(DisplayName = "")]
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
        var expected = $"....#.....{Environment.NewLine}.........#{Environment.NewLine}..........{Environment.NewLine}..#.......{Environment.NewLine}.......#..{Environment.NewLine}..........{Environment.NewLine}.#..^.....{Environment.NewLine}........#.{Environment.NewLine}#.........{Environment.NewLine}......#...";

        var actual = new Grid(input).ToString();
        
        actual.Should().Be(expected);
        logger.WriteLine(actual);
    }
}