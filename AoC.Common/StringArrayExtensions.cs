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

    public static List<Coordinate> GetSurroundingCoordinates(this Coordinate coordinate, string[] grid)
    {
        return new List<Coordinate>();
    }
}

internal class PointNotFoundException : Exception
{
    public PointNotFoundException(string message) : base(message)
    {
    }
}