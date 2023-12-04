namespace AoC.Common;

public class CoordinateGrid
{
    private readonly string[] _input;

    private readonly List<Coordinate> _coordinates = new List<Coordinate>();

    public CoordinateGrid(IReadOnlyList<string> input)
    {
        for (var y = 0; y < input.Count; y++)
        {
            var row = input[y];

            for (var x = 0; x < row.Length; x++)
            {
                _coordinates.Add(new Coordinate(x, y, row[x].ToString()));
            }
        }
    }

    public IEnumerable<Coordinate> GetSurroundingValues(Coordinate coordinate)
    {
        return _coordinates.Where(c =>
        {
            var isToTheLeft = c.X == coordinate.X - 1 && c.Y == coordinate.Y;
            var isToTheRight = c.X == coordinate.X + 1 && c.Y == coordinate.Y;
            var isAbove = c.X == coordinate.X && c.Y == coordinate.Y - 1;
            var isBelow = c.X == coordinate.X && c.Y == coordinate.Y + 1;
            var isToTheUpperLeft = false;
            var isToTheUpperRight = false;
            var isToTheLowerLeft = false;
            var isToTheLowerRight = false;

            return isToTheLeft || isToTheRight || isAbove || isBelow;
        });
    }
}

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