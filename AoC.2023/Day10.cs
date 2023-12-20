using AoC.Common;
using AoC.Common.Coordinates;

namespace AoC._2023;

public class Day10 : IDayPartOne
{
    public string Title => "--- Day 10: Pipe Maze ---";

    public object PartOne(string[] input)
    {
        var grid = new CoordinateGrid(input).RemoveByValue(".");
        var start = grid.GetCoordinateByValue("S");
        var adjacentCoords = grid.GetLinearlyAdjacentCoords(start)
            .ToList();

        var paths = new Dictionary<Coordinate, List<Coordinate>> { { start, adjacentCoords } };
        var steps = 0;

        foreach (var coord in adjacentCoords)
        {
        }

        return 0;
    }

    private static IEnumerable<Coordinate> FollowPath(Coordinate coord)
    {
        throw new NotImplementedException();
    }
}