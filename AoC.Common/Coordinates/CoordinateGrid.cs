namespace AoC.Common.Coordinates;

public class CoordinateGrid
{
    public List<Coordinate> Coordinates { get; } = new();

    public CoordinateGrid(IReadOnlyList<string> input)
    {
        for (var y = 0; y < input.Count; y++)
        {
            var row = input[y];

            for (var x = 0; x < row.Length; x++)
            {
                Coordinates.Add(new Coordinate(x, y, row[x].ToString()));
            }
        }
    }

    public IEnumerable<Coordinate> GetSurroundingCoordinates(Coordinate coordinate)
    {
        return Coordinates.Where(c => c.IsToTheLeftOf(coordinate) || c.IsToTheRightOf(coordinate) ||
                                      c.IsAbove(coordinate) ||
                                      c.IsBelow(coordinate) || c.IsToTheUpperLeftOf(coordinate) ||
                                      c.IsToTheUpperRightOf(coordinate) ||
                                      c.IsToTheBottomLeftOf(coordinate) || c.IsToTheBottomRightOf(coordinate));
    }
}