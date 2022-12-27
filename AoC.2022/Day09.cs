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