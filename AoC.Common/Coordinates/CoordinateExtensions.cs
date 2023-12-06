namespace AoC.Common.Coordinates;

public static class CoordinateExtensions
{
    public static bool IsToTheLeftOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y;
    }

    public static bool IsToTheRightOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y;
    }

    public static bool IsAbove(this Coordinate source, Coordinate target)
    {
        return source.X == target.X && source.Y == target.Y - 1;
    }

    public static bool IsBelow(this Coordinate source, Coordinate target)
    {
        return source.X == target.X && source.Y == target.Y + 1;
    }

    public static bool IsToTheUpperLeftOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y - 1;
    }

    public static bool IsToTheUpperRightOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y - 1;
    }

    public static bool IsToTheBottomLeftOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X - 1 && source.Y == target.Y + 1;
    }

    public static bool IsToTheBottomRightOf(this Coordinate source, Coordinate target)
    {
        return source.X == target.X + 1 && source.Y == target.Y + 1;
    }
}