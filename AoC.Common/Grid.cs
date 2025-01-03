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

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _input);
    }
}

record GridCoordinate(int X, int Y, string Value);