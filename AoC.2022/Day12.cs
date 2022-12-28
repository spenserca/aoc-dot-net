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
        var surroundingPoints = input.GetSurroundingCoordinates(currentPosition)
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

    private (int x, int y) GetSlope(Coordinate a, Coordinate b)
    {
        return (a.X - b.X, a.Y - b.Y);
    }

    private static (Coordinate source, Coordinate destination) GetStartingAndEndingPoint(
        string[] input,
        int maxHeight)
    {
        var source = input.GetPositionOfValue('S', 0);
        var destination = input.GetPositionOfValue('E', maxHeight);

        if (destination is null || source is null) throw new HighestPointNotFoundException();

        return (source, destination);
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}

internal class HighestPointNotFoundException : Exception
{
    public HighestPointNotFoundException() : base("Could not find highest point!")
    {
    }
}