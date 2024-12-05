namespace AoC.Common.Coordinates;

public class CoordinateGrid
{
    public List<ValueCoordinate> Coordinates { get; } = new();

    public CoordinateGrid(IReadOnlyList<string> input)
    {
        for (var y = 0; y < input.Count; y++)
        {
            var row = input[y];

            for (var x = 0; x < row.Length; x++)
            {
                Coordinates.Add(new ValueCoordinate(x, y, row[x].ToString()));
            }
        }
    }

    public IEnumerable<ValueCoordinate> GetSurroundingCoordinates(ValueCoordinate coordinate)
    {
        return Coordinates.Where(
            c =>
                c.IsToTheLeftOf(coordinate)
                || c.IsToTheRightOf(coordinate)
                || c.IsAbove(coordinate)
                || c.IsBelow(coordinate)
                || c.IsToTheUpperLeftOf(coordinate)
                || c.IsToTheUpperRightOf(coordinate)
                || c.IsToTheBottomLeftOf(coordinate)
                || c.IsToTheBottomRightOf(coordinate)
        );
    }
}
