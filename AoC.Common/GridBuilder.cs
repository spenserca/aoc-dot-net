namespace AoC.Common;

public class GridBuilder
{
    private readonly string[] _grid;
    private bool _includeRows;
    private bool _includeColumns;

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

    public GridBuilder WithColumns()
    {
        _includeColumns = true;
        return this;
    }

    public Grid Build()
    {
        var rows = (_includeRows ? _grid.Select(BuildRow) : []).ToList();
        var columns = (_includeColumns ? BuildColumns() : []).ToList();
        return new Grid(rows, columns);
    }

    private List<NewCoordinate[]> BuildColumns()
    {
        var columnLength = _grid.Length;
        var rowLength = _grid[0].Length;
        var columns = new List<NewCoordinate[]>();
        for (var x = 0; x < rowLength; x++)
        {
            var column = new NewCoordinate[columnLength];
            for (var y = 0; y < columnLength; y++)
            {
                column[y] = new NewCoordinate(x, y);
            }
            columns.Add(column);
        }
        
        return columns;
    }

    private NewCoordinate[] BuildRow(string row, int rowNumber)
    {
        return row.Select((c, i) => new NewCoordinate(rowNumber, i)).ToArray();
    }
}

public record NewCoordinate(int X, int Y);

public class Grid(List<NewCoordinate[]> rows, List<NewCoordinate[]> columns)
{
    public List<NewCoordinate[]> Rows { get; } = rows;
    public List<NewCoordinate[]> Columns { get; } = columns;
}