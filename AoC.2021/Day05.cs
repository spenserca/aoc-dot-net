using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2021;

public class Day05 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 5: Hydrothermal Venture ---";

    public object PartOne(string[] input)
    {
        return input
            .Select(ToLine)
            .Where(l => l.IsStraightLine)
            .Select(ToCoordinates)
            .SelectMany(c => c)
            .GroupBy(c => c.ToString())
            .ToDictionary(g => g.Key, g => g.Count())
            .Count(c => c.Value >= 2);
    }

    public object PartTwo(string[] input)
    {
        return input
            .Select(ToLine)
            .Select(ToCoordinates)
            .SelectMany(c => c)
            .GroupBy(c => c.ToString())
            .ToDictionary(g => g.Key, g => g.Count())
            .Count(c => c.Value >= 2);
    }

    private static LineSegment ToLine(string lineDefinition)
    {
        var coordinateRegex = new Regex("([0-9]+,[0-9]+)");
        var coordinateMatches = coordinateRegex.Matches(lineDefinition);
        var startCoordinate = GetCoordinate(coordinateMatches[0].Value);
        var endCoordinate = GetCoordinate(coordinateMatches[1].Value);
        return new LineSegment(startCoordinate, endCoordinate);
    }

    private static List<Coordinate> ToCoordinates(LineSegment line)
    {
        var coordinates = new List<Coordinate>();

        if (line.IsVertical)
        {
            var x = line.Start.X;
            var endY = line.End.Y;
            var startY = line.Start.Y;
            if (startY < endY)
            {
                for (var y = startY; y <= endY; y++)
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }
            else
            {
                for (var y = startY; y >= endY; y--)
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }
        }
        else if (line.IsHorizontal)
        {
            var y = line.Start.Y;
            var endX = line.End.X;
            var startX = line.Start.X;
            if (startX < endX)
            {
                for (var x = startX; x <= endX; x++)
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }
            else
            {
                for (var x = startX; x >= endX; x--)
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }
        }
        else
        {
            var startX = line.Start.X;
            var endX = line.End.X;
            if (startX < endX)
            {
                var startY = line.Start.Y;
                var endY = line.End.Y;
                if (startY < endY)
                {
                    for (var (x, y) = (startX, startY); x <= endX && y <= endY; x++, y++)
                    {
                        coordinates.Add(new Coordinate(x, y));
                    }
                }
                else
                {
                    for (var (x, y) = (startX, startY); x <= endX && y >= endY; x++, y--)
                    {
                        coordinates.Add(new Coordinate(x, y));
                    }
                }
            }
            else
            {
                var startY = line.Start.Y;
                var endY = line.End.Y;
                if (startY < endY)
                {
                    for (var (x, y) = (startX, startY); x >= endX && y <= endY; x--, y++)
                    {
                        coordinates.Add(new Coordinate(x, y));
                    }
                }
                else
                {
                    for (var (x, y) = (startX, startY); x >= endX && y >= endY; x--, y--)
                    {
                        coordinates.Add(new Coordinate(x, y));
                    }
                }
            }
        }

        return coordinates;
    }

    private static Coordinate GetCoordinate(string coordinateMatches)
    {
        var values = coordinateMatches.Split(',').Select(v => Convert.ToInt32(v)).ToArray();

        return new Coordinate(values[0], values[1]);
    }
}
