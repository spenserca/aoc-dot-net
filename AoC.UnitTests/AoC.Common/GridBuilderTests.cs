using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using FluentAssertions.Execution;

namespace AoC.UnitTests.AoC.Common;

public class GridBuilderTests
{
    [Fact(DisplayName = "can build a grid with rows")]
    public void CanBuildGridWithRows()
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
            .WithRows()
            .Build();

        using (new AssertionScope())
        {
            foreach (var row in input)
            {
                var x = input.ToList().FindIndex(v => v.Equals(row));
                var expected = new List<ValueCoordinate>();
                var max = row.Length;
                for (var i = 0; i < max; i++)
                {
                    expected.Add(new ValueCoordinate(x, i, new Number(input[x][i])));
                }

                actual.Rows[x].Should().BeEquivalentTo(expected);
            }
        }
    }

    [Fact(DisplayName = "can build a grid with columns")]
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
            .WithColumns()
            .Build();

        using (new AssertionScope())
        {
            var startingX = input[0].Select((v, i) => i);
            foreach (var x in startingX)
            {
                var expected = new List<ValueCoordinate>();
                var y = 0;
                while (y < input.Length)
                {
                    expected.Add(new ValueCoordinate(x, y, new Number(input[x][y])));
                    y++;
                }

                actual.Columns[x].Should().BeEquivalentTo(expected);
            }
        }
    }
}