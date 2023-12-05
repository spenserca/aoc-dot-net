using AoC.Common;
using AoC.Common.Coordinates;

namespace AoC._2023;

public class Day03 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 3: Gear Ratios ---";

    public object PartOne(string[] input)
    {
        var enginePart = string.Empty;
        var sum = 0;

        var grid = new CoordinateGrid(input);
        var isSymbolAdjacent = false;

        foreach (var coordinate in grid.Coordinates)
        {
            if (int.TryParse(coordinate.Value, out _))
            {
                var adjacentCoordinates = grid.GetSurroundingCoordinates(coordinate);
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

    public object PartTwo(string[] input)
    {
        var grid = new CoordinateGrid(input);
        var gearLikeCoordinates = grid.Coordinates.Where(c => c.Value.Equals("*"))
            .ToList();
        var sum = 0;

        foreach (var coordinate in gearLikeCoordinates)
        {
            var adjacentNumericCoordinates = grid.GetSurroundingCoordinates(coordinate)
                .Where(c => int.TryParse(c.Value, out _))
                .ToList();
            if (adjacentNumericCoordinates.Count == 2)
                sum += int.Parse(adjacentNumericCoordinates[0].Value) * int.Parse(adjacentNumericCoordinates[1].Value);
        }

        return sum;
    }
}