using AoC.Common;

namespace AoC._2024;

public class Day10 : IDayPartOne
{
    public string Title => "--- Day 10: Hoof It ---";

    public object PartOne(string[] input)
    {
        var grid = GridBuilder.FromInput(input)
            .Build();

        
        
        return 0;
    }
}

public record Trail();

public record TrailHead(List<Trail> Trails);