using AoC.Common;

namespace AoC._2022;

public class Day09 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 9: Rope Bridge ---";

    public object PartOne(string[] input)
    {
        var headPosition = new Coordinate(0, 0);
        var tailPosition = new Coordinate(0, 0);
        var uniqueTailPositions = new HashSet<Coordinate> { tailPosition };

        foreach (var motion in input)
        {
            var (direction, steps) = ParseMotion(motion);

            for (var i = 0; i < steps; i++)
            {
                headPosition = headPosition.MoveInDirection(direction);

                while (!headPosition.IsAdjacentTo(tailPosition))
                {
                    tailPosition = tailPosition.MoveTowards(headPosition);
                    uniqueTailPositions.Add(tailPosition);
                }
            }
        }

        return uniqueTailPositions.Count;
    }

    public object PartTwo(string[] input)
    {
        var uniqueTailPositions = new HashSet<Coordinate>() { new(0, 0) };
        var knotPositions = new Coordinate[]
        {
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0)
        };

        foreach (var motion in input)
        {
            var (direction, steps) = ParseMotion(motion);

            for (var i = 0; i < steps; i++)
            {
                knotPositions[0] = knotPositions[0].MoveInDirection(direction);

                for (var j = 1; j < knotPositions.Length; j++)
                {
                    var positionToFollow = knotPositions[j - 1];

                    while (!knotPositions[j].IsAdjacentTo(positionToFollow))
                    {
                        knotPositions[j] = knotPositions[j].MoveTowards(positionToFollow);

                        var isTailOfRope = j == knotPositions.Length - 1;
                        if (isTailOfRope)
                        {
                            uniqueTailPositions.Add(knotPositions[j]);
                        }
                    }
                }
            }
        }

        return uniqueTailPositions.Count;
    }

    private static (string direction, int steps) ParseMotion(string motion)
    {
        var motionPieces = motion.Split(' ');
        var direction = motionPieces[0];
        var steps = int.Parse(motionPieces[1]);

        return (direction, steps);
    }
}

public record Coordinate(int X, int Y)
{
    public Coordinate MoveUp() => this with { Y = Y + 1 };

    public Coordinate MoveDown() => this with { Y = Y - 1 };

    public Coordinate MoveLeft() => this with { X = X - 1 };
    public Coordinate MoveRight() => this with { X = X + 1 };
};

public static class CoordinateExtensions
{
    public static bool IsAdjacentTo(this Coordinate a, Coordinate b)
    {
        return Math.Abs(a.X - b.X) <= 1 && Math.Abs(a.Y - b.Y) <= 1;
    }

    public static Coordinate MoveTowards(this Coordinate a, Coordinate b)
    {
        var isInSameRow = a.X == b.X;
        var isBelowHead = a.Y < b.Y;

        if (isInSameRow)
        {
            return isBelowHead ? a.MoveUp() : a.MoveDown();
        }

        var isInSameColumn = a.Y == b.Y;
        var isLeftOfHead = a.X < b.X;

        if (isInSameColumn)
        {
            return isLeftOfHead ? a.MoveRight() : a.MoveLeft();
        }

        if (isLeftOfHead)
        {
            return isBelowHead ? a.MoveRight().MoveUp() : a.MoveRight().MoveDown();
        }

        return isBelowHead ? a.MoveLeft().MoveUp() : a.MoveLeft().MoveDown();
    }

    public static Coordinate MoveInDirection(this Coordinate currentPosition, string direction)
    {
        return direction switch
        {
            "R" => currentPosition.MoveRight(),
            "L" => currentPosition.MoveLeft(),
            "U" => currentPosition.MoveUp(),
            "D" => currentPosition.MoveDown(),
            _ => currentPosition
        };
    }
}