using System.Text;

namespace AoC.Common;

public class GridBuilder
{
    private readonly string[] _input;
    private bool _includeRows;
    private bool _includeColumns;
    private bool _includeSlopes;
    private readonly Coordinate _topLeftCorner;
    private readonly Coordinate _topRightCorner;
    private readonly Coordinate _bottomLeftCorner;
    private readonly Coordinate _bottomRightCorner;
    private int _rowCount;
    private int _columnCount;

    private GridBuilder(string[] input)
    {
        _rowCount = input.Length - 1;
        _columnCount = input[0].Length - 1;
        _input = input;
        _topLeftCorner = new Coordinate(0, 0);
        _topRightCorner = new Coordinate(0, _columnCount);
        _bottomLeftCorner = new Coordinate(0, _rowCount);
        _bottomRightCorner = new Coordinate(_rowCount, _columnCount);
    }

    public static GridBuilder FromInput(string[] input)
    {
        return new GridBuilder(input);
    }

    public GridBuilder IncludeRows()
    {
        _includeRows = true;
        return this;
    }

    public GridBuilder IncludeColumns()
    {
        _includeColumns = true;
        return this;
    }

    public GridBuilder IncludeSlopes()
    {
        _includeSlopes = true;
        return this;
    }

    public Grid Build()
    {
        return new Grid(
            BuildRows(),
            BuildColumns(),
            BuildSlopes()
        );
    }

    private IEnumerable<string>? BuildSlopes()
    {   
        if (!_includeSlopes) return null;

        var diagonals = new List<string>();

        var lines = new List<LineSegment>();
        
        // negative slope \
        // get lines above
        var startX = 0;
        var startY = 0;
        var endX = _columnCount;
        var endY = _rowCount;
        while (startX != _columnCount && endY != 0)
        {
            var nextStart = new Coordinate(startX, startY); // y doesn't change
            var nextEnd = new Coordinate(endX, endY); // x doesn't change
            lines.Add(new LineSegment(nextStart, nextEnd));
            startX++;
            endY--;
        }
        
        // get lines below
        startX = 0;
        startY = 0;
        endX = _columnCount;
        endY = _rowCount;
        while (startX != _columnCount && endY != 0)
        {
            var nextStart = new Coordinate(startX, startY); // x doesn't change
            var nextEnd = new Coordinate(endX, endY); // y doesn't change
            lines.Add(new LineSegment(nextStart, nextEnd));
            startX++;
            endY--;
        }
        
        // positive slope /
        // get lines above

        startX = _topRightCorner.X;
        startY = _topRightCorner.Y;
        endX = _bottomLeftCorner.X;
        endY = _bottomLeftCorner.Y;
        while (startX != 0 && endY != 0)
        {
            var nextStart = new Coordinate(startX, startY); // y stays the same
            var nextEnd = new Coordinate(endX, endY); // x stays the same
            lines.Add(new LineSegment(nextStart, nextEnd));
            startX--;
            endY--;
        }
        
        // get lines below /|
        startX = _topRightCorner.X;
        startY = _topRightCorner.Y;
        endX = _bottomLeftCorner.X;
        endY = _bottomLeftCorner.Y;
        while (startY != _rowCount && endX != _columnCount)
        {
            var nextStart = new Coordinate(startX, startY); // x stays the same, y goes to row count
            var nextEnd = new Coordinate(endX, endY); // y stays the same, x goes to column count
            lines.Add(new LineSegment(nextStart, nextEnd));
            startY++;
            endX++;
        }
        
        return diagonals;
    }

    private IEnumerable<string>? BuildColumns()
    {
        if (!_includeColumns) return null;
        
        var columns = new List<string>();
        for (var column = 0; column < _input[0].Length; column++)
        {
            var columnBuilder = new StringBuilder();
            for (int row = 0; row < _input.Length; row++)
            {
                columnBuilder.Append(_input[row][column]);
            }
            columns.Add(columnBuilder.ToString());
            columnBuilder.Clear();
        }
        
        return columns;
    }

    private IEnumerable<string>? BuildRows() => _includeRows ? _input : null;
}

public class Grid(
    IEnumerable<string>? rows = null,
    IEnumerable<string>? columns = null,
    IEnumerable<string>? slopes = null)
{
    public readonly IEnumerable<string> Rows = rows ?? [];
    public readonly IEnumerable<string> Columns = columns ?? [];
    public readonly IEnumerable<string> Slopes = slopes ?? [];
}

// public class LineSegment(Coordinate start, Coordinate end)
// {
//     private readonly Coordinate _start = start;
//     private readonly Coordinate _end = end;
//     private List<Coordinate> _vertices = new();
//     
//     public List<Coordinate> Vertices => _vertices.Any() ? _vertices : CalculateVertices();
//
//     private List<Coordinate> CalculateVertices()
//     {
//         var vertices = new List<Coordinate>();
//         // TODO: fill this out
//         
//         _vertices = vertices;
//         return vertices;
//     }
// }