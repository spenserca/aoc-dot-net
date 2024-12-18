namespace AoC.Common;

public class GridBuilder
{
    private readonly string[] _grid;
    private bool _includeRows;

    protected GridBuilder(string[] grid)
    {
        _grid = grid;
    }

    public static GridBuilder FromInput(string[] input)
    {
        return new GridBuilder(input);
    }

    public GridBuilder WithRows()
    {
        _includeRows = true;
        return this;
    }

    public Grid Build()
    {
        var rows = (_includeRows ? _grid.Select(BuildRow) : []).ToList();
        return new Grid(rows);
    }

    private NewCoordinate[] BuildRow(string row, int rowNumber)
    {
        return row.Select((c, i) => new NewCoordinate(rowNumber, i)).ToArray();
    }
}

public record NewCoordinate(int X, int Y);

public class Grid(List<NewCoordinate[]> rows)
{
    public List<NewCoordinate[]> Rows { get; } = rows;
}