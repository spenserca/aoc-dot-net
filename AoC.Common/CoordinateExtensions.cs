namespace AoC.Common;

public static class CoordinateExtensions
{
    public static bool IsAdjacentTo(this Coordinate a, Coordinate b)
    {
        return Math.Abs(a.X - b.X) <= 1 && Math.Abs(a.Y - b.Y) <= 1;
    }

    public static Coordinate IncrementY(this Coordinate a, int incrementBy)
    {
        return a with { Y = a.Y + incrementBy };
    }

    public static Coordinate DecrementY(this Coordinate a, int decrementBy)
    {
        return a with { Y = a.Y - decrementBy };
    }

    public static Coordinate IncrementX(this Coordinate a, int incrementBy)
    {
        return a with { X = a.X + incrementBy };
    }

    public static Coordinate DecrementX(this Coordinate a, int decrementBy)
    {
        return a with { X = a.X - decrementBy };
    }
    
    public static Coordinate MoveTowards(this Coordinate a, Coordinate b)
    {
        var isInSameRow = a.X == b.X;
        var isBelowHead = a.Y < b.Y;

        if (isInSameRow)
        {
            return isBelowHead ? a.IncrementY(1) : a.IncrementY(-1);
        }

        var isInSameColumn = a.Y == b.Y;
        var isLeftOfHead = a.X < b.X;

        if (isInSameColumn)
        {
            return isLeftOfHead ? a.IncrementX(1) : a.IncrementX(-1);
        }

        if (isLeftOfHead)
        {
            return isBelowHead ? a.IncrementX(1).IncrementY(1) : a.IncrementX(1).IncrementY(-1);
        }

        return isBelowHead ? a.IncrementX(-1).IncrementY(1) : a.IncrementX(-1).IncrementY(-1);
    }

    public static Coordinate MoveInDirection(this Coordinate currentPosition, string direction)
    {
        return direction switch
        {
            "R" => currentPosition.IncrementX(1),
            "L" => currentPosition.IncrementX(-1),
            "U" => currentPosition.IncrementY(1),
            "D" => currentPosition.IncrementY(-1),
            _ => currentPosition
        };
    }
}