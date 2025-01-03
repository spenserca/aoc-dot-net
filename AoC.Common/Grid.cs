using System.Text;

namespace AoC.Common;

public class Grid
{
    private string[] _input;
    private List<GridCoordinate> Coordinates { get; } = new();
    
    public Grid(string[] input)
    {
        _input = input;
        for (var y = 0; y < input.Length; y++)
        {
            var row = input[y];

            for (var x = 0; x < row.Length; x++)
            {
                Coordinates.Add(new GridCoordinate(x, y, row[x].ToString()));
            }
        }
    }

    public GridCoordinate? GetByValue(string value)
    {
        return Coordinates.FirstOrDefault(c => c.Value == value);
    }

    public GridCoordinate? GetValueInDirection(GridCoordinate current, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: return GetValueAtLocation(current.X, current.Y - 1);
            case Direction.Down: return GetValueAtLocation(current.X, current.Y + 1);
            case Direction.Left: return GetValueAtLocation(current.X - 1, current.Y);
            case Direction.Right: return GetValueAtLocation(current.X + 1, current.Y);
            default: return null;
        }
    }

    private GridCoordinate? GetValueAtLocation(int x, int y)
    {
        return Coordinates.FirstOrDefault(c => c.X == x && c.Y == y);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _input);
    }
}

public record GridCoordinate(int X, int Y, string Value);

public enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3
}