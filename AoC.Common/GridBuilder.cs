namespace AoC.Common;

public class GridBuilder
{
    private readonly string[] _grid;
    private bool _includeRows;
    private bool _includeColumns;

    private GridBuilder(string[] grid)
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

    private List<ValueCoordinate[]> BuildColumns()
    {
        var columnLength = _grid.Length;
        var columns = new List<ValueCoordinate[]>();
        for (var x = 0; x < _grid[0].Length; x++)
        {
            var column = new ValueCoordinate[columnLength];
            for (var y = 0; y < columnLength; y++)
            {
                column[y] = new ValueCoordinate(x, y, new Number(_grid[x][y]));
            }

            columns.Add(column);
        }

        return columns;
    }

    private ValueCoordinate[] BuildRow(string row, int rowNumber)
    {
        return row.Select((c, i) => new ValueCoordinate(rowNumber, i, new Number(_grid[rowNumber][i]))).ToArray();
    }
}

public record Number
{
    private readonly string _value;

    public Number(char value)
    {
        _value = value.ToString();
    }

    public int Value => int.Parse(_value);
}

public record ValueCoordinate(int X, int Y, Number Value);

public class Grid(List<ValueCoordinate[]> rows, List<ValueCoordinate[]> columns)
{
    public List<ValueCoordinate[]> Rows { get; } = rows;
    public List<ValueCoordinate[]> Columns { get; } = columns;
}