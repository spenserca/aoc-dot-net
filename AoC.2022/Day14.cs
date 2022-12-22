using AoC.Common;

namespace AoC._2022;

public class Day14 : IDay
{
    public string Title => "--- Day 14: Regolith Reservoir ---";

    public object PartOne(string[] input)
    {
        // abyss point = lowest y value
        var flowPoint = new Coordinate(500, 0);
        var pointOfNoReturn = new Coordinate(493, 9);
        var occupiedPoints = new HashSet<Coordinate>();
        var rockPaths = new List<RockPath>();

        // set up initial rock paths/occupied points
        foreach (var path in input)
        {
            var rockPath = new RockPath(path);
            rockPaths.Add(rockPath);
            rockPaths.ForEach(rp => rp.PathCoordinates.ToList().ForEach(pc => occupiedPoints.Add(pc)));
        }

        var isSandFallingIntoTheAbyss = false;
        var sandCount = 0;
        var sandPosition = flowPoint;

        while (!isSandFallingIntoTheAbyss)
        {
            // move down if possible
            if (!occupiedPoints.Contains(sandPosition.MoveUp()))
            {
                sandPosition = sandPosition.MoveUp();
                isSandFallingIntoTheAbyss = sandPosition == pointOfNoReturn;
            }
            // else move down and left if possible
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveLeft()))
            {
                sandPosition = sandPosition.MoveUp().MoveLeft();
                isSandFallingIntoTheAbyss = sandPosition == pointOfNoReturn;
            }
            // else move down and right if possible
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveRight()))
            {
                sandPosition = sandPosition.MoveUp().MoveRight();
                isSandFallingIntoTheAbyss = sandPosition == pointOfNoReturn;
            }
            // else sand stops -- reset sandPosition, increment sand counter
            else
            {
                occupiedPoints.Add(sandPosition);
                sandCount++;
                isSandFallingIntoTheAbyss = sandPosition == pointOfNoReturn;
                sandPosition = flowPoint;
            }
        }


        return sandCount;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}

public class RockPath
{
    public HashSet<Coordinate> PathCoordinates { get; set; } = new();

    public RockPath(string path)
    {
        var pathCoordinates = path.Split(" -> ")
            .Select(p =>
            {
                var coords = p.Split(',')
                    .Select(int.Parse).ToArray();

                var coord = new Coordinate(coords[0], coords[1]);
                PathCoordinates.Add(coord);

                return coord;
            }).ToArray();

        for (var i = 0; i < pathCoordinates.Length - 1; i++)
        {
            var start = pathCoordinates[i];
            var end = pathCoordinates[i + 1];

            if (start.Y == end.Y)
            {
                MoveAlongXAxis(start, end)
                    .ToList().ForEach(c => PathCoordinates.Add(c));
            }
            else if (start.X == end.X)
            {
                MoveAlongYAxis(start, end).ToList()
                    .ForEach(c => PathCoordinates.Add(c));
            }
        }
    }

    private IEnumerable<Coordinate> MoveAlongYAxis(Coordinate start, Coordinate end)
    {
        // assumption: x always increases "down"
        var steps = new List<Coordinate>();
        var yDiff = Math.Abs(start.Y - end.Y);
        var nextStep = start;

        if (start.Y > end.Y)
        {
            // move "up" -- decrement Y
            for (var i = 0; i < yDiff; i++)
            {
                nextStep = nextStep.MoveDown();
                steps.Add(nextStep);
            }
        }
        else
        {
            // move "down" -- increment Y
            for (var i = 0; i < yDiff; i++)
            {
                nextStep = nextStep.MoveUp();
                steps.Add(nextStep);
            }
        }


        return steps;
    }

    private static IEnumerable<Coordinate> MoveAlongXAxis(Coordinate start, Coordinate end)
    {
        var steps = new List<Coordinate>();
        var xDiff = Math.Abs(start.X - end.X);
        var nextStep = start;

        if (start.X > end.X)
        {
            // move left
            for (var i = 0; i < xDiff; i++)
            {
                nextStep = nextStep.MoveLeft();
                steps.Add(nextStep);
            }
        }
        else
        {
            // move right
            for (var i = 0; i < xDiff; i++)
            {
                nextStep = nextStep.MoveRight();
                steps.Add(nextStep);
            }
        }

        return steps;
    }
}