namespace AoC.Common;

public static class StringArrayExtensions
{
    public static Coordinate GetPositionOfValue(this string[] input, char value, int height)
    {
        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input[y].Length; x++)
            {
                if (input[y][x] == value) return new Coordinate(x, y, height);
            }
        }

        throw new PointNotFoundException($"Couldn't find a point with the value {value}");
    }

    public static List<Coordinate> GetSurroundingCoordinates(this string[] input, Coordinate coordinate)
    {
        var surroundingCoordinates = new List<Coordinate>
        {
            new(coordinate.X + 1, coordinate.Y),
            new(coordinate.X, coordinate.Y + 1),
            new(coordinate.X - 1, coordinate.Y),
            new(coordinate.X, coordinate.Y - 1)
        };

        return surroundingCoordinates.Where(c => IsInYRange(input, c) && IsInXRange(input, c)).ToList();
    }

    private static bool IsInXRange(IReadOnlyList<string> input, Coordinate coordinate) =>
        coordinate.X >= 0 && coordinate.X < input[0].Length;

    private static bool IsInYRange(string[] input, Coordinate coordinate) =>
        coordinate.Y >= 0 && coordinate.Y < input.Length;
}

internal class PointNotFoundException : Exception
{
    public PointNotFoundException(string message) : base(message)
    {
    }
}