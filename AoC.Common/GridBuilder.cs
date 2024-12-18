namespace AoC.Common;

public class GridBuilder
{
    private readonly string[] _grid;
    private Predicate<ValueCoordinate>? _findValuesPredicate;

    private GridBuilder(string[] grid)
    {
        _grid = grid;
    }

    public static GridBuilder FromInput(string[] input)
    {
        return new GridBuilder(input);
    }

    public GridBuilder IncludeFilteredSubset(Predicate<ValueCoordinate> predicate)
    {
        _findValuesPredicate = predicate;
        return this;
    }

    public ValueGrid Build()
    {
        var coords = new List<ValueCoordinate>();
        for (var y = 0; y < _grid.Length; y++)
        {
            for (var x = 0; x < _grid[0].Length; x++)
            {
                coords.Add(new ValueCoordinate(x, y, new Number(_grid[x][y])));       
            }
        }
        
        return new ValueGrid(coords, _findValuesPredicate);
    }
}

public record Number
{
    private readonly string _value;

    public Number(char value)
    {
        _value = value.ToString();
    }

    public int AsInt => int.Parse(_value);
}

public record ValueCoordinate(int X, int Y, Number Value);

public record ValueGrid(List<ValueCoordinate> Coordinates, Predicate<ValueCoordinate>? Predicate)
{
    public List<ValueCoordinate> FilteredSubset => Predicate is null ? [] : Coordinates.Where(v => Predicate.Invoke(v)).ToList();
}