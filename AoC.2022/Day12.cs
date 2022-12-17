using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2022;

public class Day12 : IDay
{
    public string Title => "--- Day 12: Hill Climbing Algorithm ---";

    public object PartOne(string[] input)
    {
        const string heights = "abcdefghijklmnopqrstuvwxyz";
        var currentPoint = new Coordinate(0, 0, heights.IndexOf('a'));
        var highestPoint = GetHighestPoint(input, heights.IndexOf('z'));
        var steps = 0;

        // option 1:
        // get all points that can be moved to
        // calculate the distance from each point to the highest point
        // move to the one that's closest
        while (currentPoint != highestPoint)
        {
            steps++;
            var surroundingPoints = GetSurroundingPoints(currentPoint, input)
                .Where(c => Math.Abs(heights.IndexOf(input[c.Y][c.X]) - currentPoint.Z) <= 1)
                .ToList();
            var coordinateClosestToHighestPoint = GetPointClosestToHighestPoint(surroundingPoints, highestPoint);

            currentPoint = coordinateClosestToHighestPoint;
        }

        // option 2:
        // find the slope between the current point and the highest point
        // move along that slop towards highest point
        // get straight line slope to highest point

        // var (x, y) = GetSlope(currentPoint, highestPoint);

        // find which positions to move to that follow that line

        // if 

        return steps;
    }

    private static Coordinate GetPointClosestToHighestPoint(IEnumerable<Coordinate> sourcePoints,
        Coordinate destinationPoint)
    {
        var distanceCoordinateMap = new Dictionary<double, Coordinate>();

        foreach (var sourcePoint in sourcePoints)
        {
            var xDistance = destinationPoint.X - sourcePoint.X;
            var yDistance = destinationPoint.Y - sourcePoint.Y;
            var distanceToDestination = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
            distanceCoordinateMap.Add(distanceToDestination, sourcePoint);
        }

        var minDistance = distanceCoordinateMap.Keys.Min();

        return distanceCoordinateMap[minDistance];
    }

    private IEnumerable<Coordinate> GetSurroundingPoints(Coordinate point, string[] input)
    {
        var surroundingPoints = new List<Coordinate>();
        var isOnLeftBoundary = point.X == 0;
        var isOnRightBoundary = point.X == input[0].Length - 1;
        var isTopBoundary = point.Y == 0;
        var isBottomBoundary = point.Y == input.Length - 1;

        if (isTopBoundary)
        {
            if (isOnLeftBoundary)
            {
                surroundingPoints.Add(point.MoveRight());
                surroundingPoints.Add(point.MoveUp());
            }
            else
            {
                if (isOnRightBoundary)
                {
                    surroundingPoints.Add(point.MoveLeft());
                    surroundingPoints.Add(point.MoveUp());
                }
                else
                {
                    surroundingPoints.Add(point.MoveLeft());
                    surroundingPoints.Add(point.MoveRight());
                    surroundingPoints.Add(point.MoveUp());
                }
            }
        }
        else if (isBottomBoundary)
        {
            if (isOnLeftBoundary)
            {
                surroundingPoints.Add(point.MoveRight());
                surroundingPoints.Add(point.MoveDown());
            }
            else if (isOnRightBoundary)
            {
                surroundingPoints.Add(point.MoveLeft());
                surroundingPoints.Add(point.MoveDown());
            }
            else
            {
                surroundingPoints.Add(point.MoveLeft());
                surroundingPoints.Add(point.MoveRight());
                surroundingPoints.Add(point.MoveDown());
            }
        }
        else
        {
            surroundingPoints.Add(point.MoveUp());
            surroundingPoints.Add(point.MoveDown());
            surroundingPoints.Add(point.MoveRight());
            surroundingPoints.Add(point.MoveLeft());
        }


        return surroundingPoints;
    }

    private (int x, int y) GetSlope(Coordinate a, Coordinate b)
    {
        return (a.X - b.X, a.Y - b.Y);
    }

    private static Coordinate GetHighestPoint(IReadOnlyList<string> input, int maxHeight)
    {
        for (var y = 0; y < input.Count; y++)
        {
            for (var x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == 'E') return new Coordinate(x, y, maxHeight);
            }
        }

        throw new HighestPointNotFoundException();
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private record Coordinate(int X, int Y, int Z)
    {
        public Coordinate MoveUp() => this with { Y = Y + 1 };
        public Coordinate MoveDown() => this with { Y = Y - 1 };
        public Coordinate MoveLeft() => this with { X = X - 1 };
        public Coordinate MoveRight() => this with { X = X + 1 };
    };
}

internal class HighestPointNotFoundException : Exception
{
    public HighestPointNotFoundException() : base("Could not find highest point!")
    {
    }
}