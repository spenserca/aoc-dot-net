using AoC.Common;

namespace AoC._2022;

public class Day14 : IDay
{
    public string Title => "--- Day 14: Regolith Reservoir ---";

    public object PartOne(string[] input)
    {
        var flowPoint = new Coordinate(500, 0);
        var occupiedPoints = new HashSet<Coordinate>();
        var rockPaths = new List<RockPath>();
        
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
            if (!occupiedPoints.Contains(sandPosition.MoveUp()))
            {
                sandPosition = sandPosition.MoveUp();
            }
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveLeft()))
            {
                sandPosition = sandPosition.MoveUp().MoveLeft();
            }
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveRight()))
            {
                sandPosition = sandPosition.MoveUp().MoveRight();
            }
            else
            {
                occupiedPoints.Add(sandPosition);
                sandCount++;
                sandPosition = flowPoint;
            }

            var hasOccupiedPointsBelow = occupiedPoints
                .Any(c => c.X == sandPosition.X && c.Y > sandPosition.Y);

            isSandFallingIntoTheAbyss = !hasOccupiedPointsBelow;
        }

        return sandCount;
    }

    public object PartTwo(string[] input)
    {
        var flowPoint = new Coordinate(500, 0);
        var occupiedPoints = new HashSet<Coordinate>();
        var rockPaths = new List<RockPath>();

        foreach (var path in input)
        {
            var rockPath = new RockPath(path);
            rockPaths.Add(rockPath);
            rockPaths.ForEach(rp => rp.PathCoordinates.ToList().ForEach(pc => occupiedPoints.Add(pc)));
        }

        // add floor as rock path @ max Y + 2
        var floorLevel = rockPaths.SelectMany(rp => rp.PathCoordinates.Select(pc => pc.Y))
            .Max() + 2;

        var isFlowPointBlocked = false;
        var sandCount = 0;
        var sandPosition = flowPoint;

        while (!isFlowPointBlocked)
        {
            if (!occupiedPoints.Contains(sandPosition.MoveUp()) && sandPosition.MoveUp().Y < floorLevel)
            {
                sandPosition = sandPosition.MoveUp();
            }
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveLeft()) && sandPosition.MoveUp().Y < floorLevel)
            {
                sandPosition = sandPosition.MoveUp().MoveLeft();
            }
            else if (!occupiedPoints.Contains(sandPosition.MoveUp().MoveRight()) && sandPosition.MoveUp().Y < floorLevel)
            {
                sandPosition = sandPosition.MoveUp().MoveRight();
            }
            else
            {
                isFlowPointBlocked = sandPosition == flowPoint;
                occupiedPoints.Add(sandPosition);
                sandCount++;
                sandPosition = flowPoint;
            }
        }

        return sandCount;
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

    private static IEnumerable<Coordinate> MoveAlongYAxis(Coordinate start, Coordinate end)
    {
        var steps = new List<Coordinate>();
        var yDiff = Math.Abs(start.Y - end.Y);
        var nextStep = start;

        if (start.Y > end.Y)
        {
            for (var i = 0; i < yDiff; i++)
            {
                nextStep = nextStep.MoveDown();
                steps.Add(nextStep);
            }
        }
        else
        {
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
            for (var i = 0; i < xDiff; i++)
            {
                nextStep = nextStep.MoveLeft();
                steps.Add(nextStep);
            }
        }
        else
        {
            for (var i = 0; i < xDiff; i++)
            {
                nextStep = nextStep.MoveRight();
                steps.Add(nextStep);
            }
        }

        return steps;
    }
}