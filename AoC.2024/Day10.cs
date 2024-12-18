using AoC.Common;

namespace AoC._2024;

public class Day10 : IDayPartOne
{
    public string Title => "--- Day 10: Hoof It ---";

    public object PartOne(string[] input)
    {
        var grid = GridBuilder.FromInput(input)
            .WithRows()
            .WithColumns()
            .Build();

        foreach (var row in grid.Rows)
        {
            
        }

        return 0;
    }
}

public record StringNumber(char Value)
{
    public int Int => int.Parse(Value.ToString());
}

public record Trail();

public record TrailHead(List<Trail> Trails);