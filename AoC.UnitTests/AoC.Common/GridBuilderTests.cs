using AoC.Common;
using FluentAssertions.Execution;

namespace AoC.UnitTests.AoC.Common;

public class GridBuilderTests
{
    [Fact(DisplayName = "when rows should be included, the rows are returned in the grid")]
    public void IncludeRowsInGrid()
    {
        var input = new[]
        {
            "12345",
            "ABCDE",
            "23456",
            "FGHIJ",
            "34567",
        };

        var grid = GridBuilder.FromInput(input)
            .IncludeRows()
            .Build();

        using (new AssertionScope())
        {
            grid.Rows.Should().HaveCount(5);
            grid.Rows.Should().BeEquivalentTo(input);
            grid.Columns.Should().BeEmpty();
            grid.Slopes.Should().BeEmpty();
            grid.Slopes.Should().BeEmpty();
        }
    }

    [Fact(DisplayName = "when columns should be included, the columns are returned in the grid")]
    public void IncludeColumnsInGrid()
    {
        var input = new[]
        {
            "12345",
            "ABCDE",
            "23456",
            "FGHIJ",
            "34567",
        };
        
        var expected = new[]
        {
            "1A2F3",
            "2B3G4",
            "3C4H5",
            "4D5I6",
            "5E6J7",
        };

        var grid = GridBuilder.FromInput(input)
            .IncludeColumns()
            .Build();

        using (new AssertionScope())
        {
            grid.Columns.Should().HaveCount(5);
            grid.Columns.Should().BeEquivalentTo(expected);
            grid.Rows.Should().BeEmpty();
            grid.Slopes.Should().BeEmpty();
            grid.Slopes.Should().BeEmpty();
        }
    }

    [Fact(DisplayName = "when diagonals should be included, then upward diagonals are returned in the grid")]
    public void IncludeDiagonalsInGridUpwardDiagonals()
    {
        var input = new[]
        {
            "12345",
            "ABCDE",
            "23456",
            "FGHIJ",
            "34567",
        };
        
        var expected = new[]
        {
            "1",
            "A2",
            "2B3",
            "F3C4",
            "3G4D5",
            "4H5E",
            "5I6",
            "6J",
            "7",
        };

        var grid = GridBuilder.FromInput(input)
            .IncludeSlopes()
            .Build();

        using (new AssertionScope())
        {
            grid.Slopes.Should().HaveCount(expected.Length);
            grid.Slopes.Should().BeEquivalentTo(expected);
            grid.Rows.Should().BeEmpty();
            grid.Columns.Should().BeEmpty();
        }
    }
    
    [Fact(DisplayName = "when diagonals should be included, then downward diagonals are returned in the grid")]
    public void IncludeDiagonalsInGridDownwardDiagonals()
    {
        var input = new[]
        {
            "12345",
            "ABCDE",
            "23456",
            "FGHIJ",
            "34567",
        };
        
        var expected = new[]
        {
            "3",
            "F4",
            "2G5",
            "A3H6",
            "1B4I7",
            "2C5J",
            "3D6",
            "4E",
            "5",
        };

        var grid = GridBuilder.FromInput(input)
            .IncludeSlopes()
            .Build();

        using (new AssertionScope())
        {
            grid.Slopes.Should().HaveCount(expected.Length);
            grid.Slopes.Should().BeEquivalentTo(expected);
            grid.Rows.Should().BeEmpty();
            grid.Columns.Should().BeEmpty();
        }
    }
}