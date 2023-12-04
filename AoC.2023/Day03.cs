using AoC.Common;

namespace AoC._2023;

public class Day03: IDayPartOne
{
    public string Title => "--- Day 3: Gear Ratios ---";

    private static readonly string[] Symbols = { "*", "#", "+", "$" };

    public object PartOne(string[] input)
    {
        var enginePart = string.Empty;
        var isSymbolAdjacent = false;
        var sum = 0;
        
        for (int y = 0; y < input.Length; y++)
        {
            var row = input[y];
            
            for (int x = 0; x < row.Length; x++)
            {
                var value = row[x];

                if (int.TryParse(value.ToString(), out _))
                {
                    enginePart += value;
                    
                    // check if adjacent
                    if (HasAdjacentSymbols(input, x, y)) isSymbolAdjacent = true;
                }
                else
                {
                    if (isSymbolAdjacent)
                    {
                        sum += int.Parse(enginePart);
                        isSymbolAdjacent = false;
                    }
                }
            }
        }

        return 0;
    }
    
    private static bool HasAdjacentSymbols(string[] input, int x, int y)
    {
        var surroundingCoords = GetSurroundingCoords(x, y, input.Length);

        return false;
    }

    private static IEnumerable<(int x, int y)> GetSurroundingCoords(int x, int y, int maxY)
    {
        if (x == 0)
        {
            if (y == 0)
            {
                return new (int x, int y)[] { (1, y), (1, 1), (x, 1) };
            } else if (y == maxY)
            {
                return new (int x, int y)[] { (1, y), (1, y - 1), (1, y - 1) };
            }
        }
    }
}