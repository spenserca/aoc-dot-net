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
    // vertical descending
    [InlineData(3, 8, 3, 5, new[] { 3, 3, 3, 3 }, new[] { 8, 7, 6, 5 })]
    // horizontal ascending
    [InlineData(5, 3, 8, 3, new[] { 5, 6, 7, 8 }, new[] { 3, 3, 3, 3 })]
    // horizontal descending
    [InlineData(8, 3, 5, 3, new[] { 8, 7, 6, 5 }, new[] { 3, 3, 3, 3 })]
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