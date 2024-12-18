using AoC.Common;
using FluentAssertions.Execution;

namespace AoC.UnitTests.AoC.Common;

public class GridBuilderTests
{
    [Fact(DisplayName = "can build a grid with values")]
    public void CanBuildGridWithColumns()
    {
        var input = new[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        };

        var actual = GridBuilder.FromInput(input)
            .IncludeFilteredSubset(v => v.Value.AsInt == 0)
            .Build();

        using (new AssertionScope())
        {
            actual.Coordinates.Should().HaveCount(input.Length * input[0].Length);
            actual.FilteredSubset.Should().HaveCount(9);
        }
    }
}