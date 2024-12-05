namespace AoC.Common.Coordinates;

public static class CoordinateExtensions
{
    public static bool IsToTheLeftOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y;
    }

    public static bool IsToTheRightOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y;
    }

    public static bool IsAbove(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X && source.Y == target.Y - 1;
    }

    public static bool IsBelow(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X && source.Y == target.Y + 1;
    }

    public static bool IsToTheUpperLeftOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y - 1;
    }

    public static bool IsToTheUpperRightOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y - 1;
    }

    public static bool IsToTheBottomLeftOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y + 1;
    }

    public static bool IsToTheBottomRightOf(this ValueCoordinate source, ValueCoordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y + 1;
    }
}
