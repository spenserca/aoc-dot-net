using AoC.Common;

namespace AoC._2024;

public class Day10: IDayPartOne
{
    public string Title => "--- Day 10: Hoof It ---";

    public object PartOne(string[] input)
    {
        for (var y = 0; y < input.Length; y++)
        {
            var row = input[y];
            for (int x = 0; x < row.Length; x++)
            {
                var value = new StringNumber(input[y][x]);
                if (value.Int != 0) continue;
                
                var left = input[y][x - 1];
            }
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