using AoC.Common;
using AoC.Common.Coordinates;

namespace AoC._2023;

public class Day10 : IDayPartOne
{
    public string Title => "--- Day 10: Pipe Maze ---";

    private const string NorthSouth = "|";
    private const string EastWest = "-";
    private const string NorthEast = "L";
    private const string NorthWest = "J";
    private const string SouthWest = "7";
    private const string SouthEast = "F";
    private const string Ground = ".";
    private const string Start = "S";

    public object PartOne(string[] input)
    {
        var grid = new CoordinateGrid(input).RemoveByValue(Ground);
        var start = grid.GetCoordinateByValue(Start);
        var steps = 0;

        foreach (var coord in grid.GetLinearlyAdjacentCoords(start))
        {
            if (IsContinuousLoop(coord, out var loop))
            {
                steps = loop.Count() / 2;
            }
        }

        return steps;
    }

    private static bool IsContinuousLoop(Coordinate coord, out IEnumerable<Coordinate> Loop)
    {
        Loop = Enumerable.Empty<Coordinate>();

        return false;
    }
}