using AoC.Common;
using AoC.Common.Coordinates;

namespace AoC._2023;

public class Day03 : IDayPartOne
{
    public string Title => "--- Day 3: Gear Ratios ---";

    private static readonly string[] Symbols = { "*", "#", "+", "$", "/", "=", "%", "&", "@" };

    public object PartOne(string[] input)
    {
        var enginePart = string.Empty;
        var sum = 0;

        var coordinateGrid = new CoordinateGrid(input);
        var isSymbolAdjacent = false;

        foreach (var coordinate in coordinateGrid.Coordinates)
        {
            if (int.TryParse(coordinate.Value, out _))
            {
                var adjacentCoordinates = coordinateGrid.GetSurroundingCoordinates(coordinate);
                if (!isSymbolAdjacent)
                {
                    isSymbolAdjacent =
                        adjacentCoordinates.Any(c => !int.TryParse(c.Value, out _) && !c.Value.Equals("."));
                }

                enginePart += coordinate.Value;
            }
            else
            {
                if (isSymbolAdjacent) sum += int.Parse(enginePart);
                enginePart = string.Empty;
                isSymbolAdjacent = false;
            }
        }

        return sum;
    }
}