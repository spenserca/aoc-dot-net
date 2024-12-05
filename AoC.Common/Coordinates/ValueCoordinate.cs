namespace AoC.Common.Coordinates;

public class ValueCoordinate
{
    public int X { get; }
    public int Y { get; }
    public string Value { get; }

    public ValueCoordinate(int x, int y, string value)
    {
        X = x;
        Y = y;
        Value = value;
    }
}
