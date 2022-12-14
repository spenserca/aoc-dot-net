using AoC.Common;

namespace AoC._2022;

public class Day09 : IDay
{
    public string Title => "--- Day 9: Rope Bridge ---";

    public object PartOne(string[] input)
    {
        var headPosition = new Coordinate(0, 0);
        var tailPosition = new Coordinate(0, 0);
        var uniqueTailPositions = new HashSet<Coordinate> { tailPosition };

        foreach (var motion in input)
        {
            var motionPieces = motion.Split(' ');
            var direction = motionPieces[0];
            var steps = int.Parse(motionPieces[1]);

            for (var i = 0; i < steps; i++)
            {
                // update head position
                headPosition = headPosition.IncrementPosition(direction);

                while (!headPosition.IsAdjacentTo(tailPosition))
                {
                    // move tail towards the head
                    tailPosition = tailPosition.MoveTowards(headPosition);
                    uniqueTailPositions.Add(tailPosition);
                }
            }
        }

        return uniqueTailPositions.Count;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
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

    public static Coordinate IncrementPosition(this Coordinate currentPosition, string direction)
    {
        return direction switch
        {
            "R" => currentPosition with { X = currentPosition.X + 1 },
            "L" => currentPosition with { X = currentPosition.X - 1 },
            "U" => currentPosition with { Y = currentPosition.Y + 1 },
            "D" => currentPosition with { Y = currentPosition.Y - 1 },
            _ => currentPosition
        };
    }
}