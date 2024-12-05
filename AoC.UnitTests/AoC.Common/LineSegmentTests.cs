using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using FluentAssertions.Execution;

namespace AoC.UnitTests.AoC.Common;

public class LineSegmentTests
{
    [Theory(DisplayName = "the points on the line can be calculated")]
    // vertical ascending
    [InlineData(3, 5, 3, 8, new[] { 3, 3, 3, 3 }, new[] { 5, 6, 7, 8 })]
    // vertical crossing origin ascending
    [InlineData(3, -2, 3, 3, new[] { 3, 3, 3, 3, 3, 3 }, new[] { -2, -1, 0, 1, 2, 3 })]
    // vertical descending
    [InlineData(3, 8, 3, 5, new[] { 3, 3, 3, 3 }, new[] { 8, 7, 6, 5 })]
    // vertical crossing origin descending
    [InlineData(3, 3, 3, -2, new[] { 3, 3, 3, 3, 3, 3 }, new[] { 3, 2, 1, 0, -1, -2 })]
    // horizontal ascending
    [InlineData(5, 3, 8, 3, new[] { 5, 6, 7, 8 }, new[] { 3, 3, 3, 3 })]
    // horizontal descending
    [InlineData(8, 3, 5, 3, new[] { 8, 7, 6, 5 }, new[] { 3, 3, 3, 3 })]
    // slope ascending
    [InlineData(1, 3, 5, 7, new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5, 6, 7 })]
    // slope crossing origin ascending
    [InlineData(-1, -1, 2, 2, new[] { -1, 0, 1, 2 }, new[] { -1, 0, 1, 2 })]
    // slope descending
    [InlineData(5, 7, 1, 3, new[] { 5, 4, 3, 2, 1 }, new[] { 7, 6, 5, 4, 3 })]
    // slope crossing origin descending
    [InlineData(2, 2, -1, -1, new[] { 2, 1, 0, -1 }, new[] { 2, 1, 0, -1 })]
    public void VerticalTests(int startX, int startY, int endX, int endY, int[] expectedX, int[] expectedY)
    {
        var start = new Coordinate(startX, startY);
        var end = new Coordinate(endX, endY);
        var line = new LineSegment(start, end);

        var expected = expectedX.Select((x, i) => new Coordinate(x, expectedY[i])).ToList();

        var actual = line.Points;

        using (new AssertionScope())
        {
            actual.Should().HaveCount(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}