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
                var adjacentCoordinates = grid.GetAllAdjacentCoords(coordinate);
                if (!isSymbolAdjacent)
                {
                    isSymbolAdjacent = adjacentCoordinates.Any(
                        c => !int.TryParse(c.Value, out _) && !c.Value.Equals(".")
                    );
                }

                enginePart += coordinate.Value;
            }
            else
            {
                if (isSymbolAdjacent)
                    sum += int.Parse(enginePart);
                enginePart = string.Empty;
                isSymbolAdjacent = false;
            }
        }

        return sum;
    }

    public object PartTwo(string[] input)
    {
        var enginePart = string.Empty;
        var adjacentGears = new List<Coordinate>();
        var gearsWithAdjacentEngineParts = new Dictionary<Coordinate, List<string>>();

        var grid = new CoordinateGrid(input);
        var isSymbolAdjacent = false;

        foreach (var coordinate in grid.Coordinates)
        {
            if (int.TryParse(coordinate.Value, out _))
            {
                var adjacentCoordinates = grid.GetAllAdjacentCoords(coordinate);
                if (!isSymbolAdjacent)
                {
                    var adjacentSymbols = adjacentCoordinates
                        .Where(c => !int.TryParse(c.Value, out _) && !c.Value.Equals("."))
                        .ToList();
                    isSymbolAdjacent = adjacentSymbols.Any();
                    adjacentGears.AddRange(adjacentSymbols.Where(s => s.Value.Equals("*")));
                }

                enginePart += coordinate.Value;
            }
            else
            {
                if (isSymbolAdjacent)
                {
                    foreach (var gear in adjacentGears)
                    {
                        if (!gearsWithAdjacentEngineParts.ContainsKey(gear))
                            gearsWithAdjacentEngineParts.Add(
                                gear,
                                new List<string>() { enginePart }
                            );
                        else
                            gearsWithAdjacentEngineParts[gear].Add(enginePart);
                    }
                }

                enginePart = string.Empty;
                adjacentGears.Clear();
                isSymbolAdjacent = false;
            }
        }

        return gearsWithAdjacentEngineParts
            .Values.Where(v => v.Count == 2)
            .Sum(v => int.Parse(v[0]) * int.Parse(v[1]));
    }
}
