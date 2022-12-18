using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2022;

public class Day12 : IDay
{
    public string Title => "--- Day 12: Hill Climbing Algorithm ---";

    public object PartOne(string[] input)
    {
        const string heights = "abcdefghijklmnopqrstuvwxyz";
        var (currentPosition, destination) = GetStartingAndEndingPoint(input, heights.IndexOf('z'));
        var steps = 0;

        // find the slope from current point to the highest point
        var (deltaX, deltaY) = CalculateSlope(currentPosition, destination);
        
        // find the surrounding points that are on that slope
        var surroundingPoints = GetSurroundingPoints(currentPosition, input)
            .Where(c => Math.Abs(heights.IndexOf(input[c.Y][c.X]) - currentPosition.Z) <= 1)
            .ToList();
        
        
        // for surrounding points on slope, find the one closest to highest point
        // move to closest location on slope

        // NOTE: if there is only 1 valid surrounding path, you must take it

        // option 1:
        // get all points that can be moved to
        // calculate the distance from each point to the highest point
        // move to the one that's closest
        while (currentPosition != destination)
        {
            steps++;
            // var surroundingPoints = GetSurroundingPoints(currentPosition, input)
            //     .Where(c => Math.Abs(heights.IndexOf(input[c.Y][c.X]) - currentPosition.Z) <= 1)
            //     .ToList();
            var coordinateClosestToHighestPoint = GetPointClosestToHighestPoint(surroundingPoints, destination);

            currentPosition = coordinateClosestToHighestPoint;
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

    private static (int deltaX, int deltaY) CalculateSlope(Coordinate source, Coordinate destination)
    {
        var deltaX = destination.X - source.X;
        var deltaY = destination.Y - source.Y;

        return (deltaX, deltaY);
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

    private static (Coordinate source, Coordinate destination) GetStartingAndEndingPoint(IReadOnlyList<string> input,
        int maxHeight)
    {
        Coordinate? destination = null;
        Coordinate? source = null;
        for (var y = input.Count - 1; y >= 0; y--)
        {
            for (var x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == 'E') destination = new Coordinate(x, y, maxHeight);
                if (input[y][x] == 'S') source = new Coordinate(x, y, 0);
            }
        }

        if (destination is null || source is null) throw new HighestPointNotFoundException();

        return (source, destination);
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
    }

    private class HeightMapNode
    {
        public Coordinate Location { get; set; }
        
        public List<HeightMapNode> AdjacentNodes { get; set; }
    }
}

internal class HighestPointNotFoundException : Exception
{
    public HighestPointNotFoundException() : base("Could not find highest point!")
    {
    }
}