using System.Collections.Generic;
using AoC.Common;
using FluentAssertions.Execution;

namespace AoC.UnitTests.AoC.Common;

public class LineSegmentTests
{
    [Fact(DisplayName =
        "when the line is vertical with increasing slope, then the points on the line can be calculated")]
    public void IncreasingVerticalLine()
    {
        var start = new Coordinate(3, 5);
        var end = new Coordinate(3, 8);
        var line = new LineSegment(start, end);

        var expected = new List<Coordinate>()
        {
            new(3, 5),
            new(3, 6),
            new(3, 7),
            new(3, 8),
        };

        var actual = line.Points;

        using (new AssertionScope())
        {
            actual.Should().HaveCount(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
    
    [Fact(DisplayName =
        "when the line is vertical with decreasing slope, then the points on the line can be calculated")]
    public void DecreasingVerticalLine()
    {
        var start = new Coordinate(3, 8);
        var end = new Coordinate(3, 5);
        var line = new LineSegment(start, end);

        var expected = new List<Coordinate>()
        {
            new(3, 8),
            new(3, 7),
            new(3, 6),
            new(3, 5),
        };

        var actual = line.Points;

        using (new AssertionScope())
        {
            actual.Should().HaveCount(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
    
    [Fact(DisplayName =
        "when the line is horizontal with increasing slope, then the points on the line can be calculated")]
    public void IncreasingHorizontalLine()
    {
        var start = new Coordinate(5, 3);
        var end = new Coordinate(8, 3);
        var line = new LineSegment(start, end);

        var expected = new List<Coordinate>()
        {
            new(5, 3),
            new(6, 3),
            new(7, 3),
            new(8, 3),
        };

        var actual = line.Points;

        using (new AssertionScope())
        {
            actual.Should().HaveCount(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
    
    [Fact(DisplayName =
        "when the line is horizontal with decreasing slope, then the points on the line can be calculated")]
    public void DecreasingHorizontalLine()
    {
        var start = new Coordinate(5, 3);
        var end = new Coordinate(8, 3);
        var line = new LineSegment(start, end);
        // TODO: add test cases crossing the origin, y-axis and x-axis

        var expected = new List<Coordinate>()
        {
            new(8, 3),
            new(7, 3),
            new(6, 3),
            new(5, 3),
        };

        var actual = line.Points;

        using (new AssertionScope())
        {
            actual.Should().HaveCount(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}