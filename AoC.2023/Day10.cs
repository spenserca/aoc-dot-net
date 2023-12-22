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



        return 0;
    }
    
    
}