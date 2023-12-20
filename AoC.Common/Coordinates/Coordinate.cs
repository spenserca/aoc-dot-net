namespace AoC.Common.Coordinates;

public class Coordinate
{
    public int X { get; }
    public int Y { get; }
    public string Value { get; }

    public Coordinate(int x, int y, string value)
    {
        X = x;
        Y = y;
        Value = value;
    }
}
