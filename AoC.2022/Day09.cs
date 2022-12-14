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

public record Coordinate(int X, int Y);

public static class CoordinateExtensions
{
    public static bool IsAdjacentTo(this Coordinate a, Coordinate b)
    {
        return Math.Abs(a.X - b.X) <= 1 && Math.Abs(a.Y - b.Y) <= 1;
    }

    public static Coordinate MoveTowards(this Coordinate a, Coordinate b)
    {
        // same row
        if (a.X == b.X)
        {
            if (a.Y < b.Y) return a with { Y = a.Y + 1 };
            return a with { Y = a.Y - 1 };
        }

        // same column
        if (a.Y == b.Y)
        {
            if (a.X < b.X) return a with { X = a.X + 1 };
            return a with { X = a.X - 1 };
        }

        // diagonal
        // tail is to the left of head
        if (a.X < b.X)
        {
            var x = a.X + 1;
            // tail is below the head
            if (a.Y < b.Y) return new Coordinate(x, a.Y + 1);

            // tail is above the head
            return new Coordinate(x, a.Y - 1);
        }

        // else: tail is to the right of head
        // tail is below the head
        if (a.Y < b.Y) return new Coordinate(a.X - 1, a.Y + 1);

        // tail is above the head
        return new Coordinate(a.X - 1, a.Y - 1);
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