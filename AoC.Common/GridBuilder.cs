using System.Text;

namespace AoC.Common;

public class GridBuilder
{
    private string[] _input;
    private bool _includeRows;
    private bool _includeColumns;
    private bool _includeDiagonals;

    protected GridBuilder(string[] input)
    {
        _input = input;
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

    public GridBuilder IncludeDiagonals()
    {
        _includeDiagonals = true;
        return this;
    }

    public Grid Build()
    {
        var buildUpwardDiagonals = BuildUpwardDiagonals();
        return new Grid(
            BuildRows(),
            BuildColumns(),
            buildUpwardDiagonals,
            BuildDownwardDiagonals()
        );
    }

    private IEnumerable<string>? BuildDownwardDiagonals()
    {
        if (!_includeDiagonals) return null;
        
        // for each value in each row -- get the value down and to the right of it and add to the current "row"

        return [];
    }

    private IEnumerable<string>? BuildUpwardDiagonals()
    {   
        if (!_includeDiagonals) return null;
        
        var rowCount = _input.Length;
        var columnCount = _input[0].Length;

        var diagonals = new HashSet<string>();
        for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            var diagonalBuilder = new StringBuilder();
            var startingValue = _input[rowIndex][0].ToString();
            diagonalBuilder.Append(startingValue);
            
            var upperRowIndex = rowIndex - 1;
            var columnIndex = 0;
            while (upperRowIndex >= 0)
            {
                if (columnIndex < columnCount)
                {
                    var nextValue = _input[upperRowIndex][columnIndex + 1];
                    diagonalBuilder.Append(nextValue);
                    columnIndex++;
                }

                upperRowIndex--;
            }
            
            diagonals.Add(diagonalBuilder.ToString());
            diagonalBuilder.Clear();
        }
        
        var lastRow = _input[rowCount - 1];
        for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            var diagonalBuilder = new StringBuilder();
            var startingValue = lastRow[columnIndex].ToString();
            diagonalBuilder.Append(startingValue);
            
            var nextColumnIndex = columnIndex + 1;
            var upperRowIndex = rowCount - 1;
            while (nextColumnIndex < columnCount)
            {
                if (upperRowIndex >= 0)
                {
                    upperRowIndex--;
                    var nextValue = _input[upperRowIndex][nextColumnIndex];
                    diagonalBuilder.Append(nextValue);
                }
                nextColumnIndex++;
            }
            
            diagonals.Add(diagonalBuilder.ToString());
            diagonalBuilder.Clear();
        }
        
        // for (var columnIndex = 0; columnIndex < columnCount - 1; columnIndex++)
        // {  
        //     var diagonalBuilder = new StringBuilder();
        //     var rowIndex = rowCount - 1;
        //     var startingValue = _input[rowIndex][columnIndex];
        //     diagonalBuilder.Append(startingValue);
        //     
        //     var upperRowIndex = rowIndex - 1;
        //     var nextColumnIndex = columnIndex;
        //     while (upperRowIndex >= 0)
        //     {
        //         if (nextColumnIndex < columnCount)
        //         {
        //             var nextValue = _input[upperRowIndex][nextColumnIndex + 1];
        //             diagonalBuilder.Append(nextValue);
        //             nextColumnIndex++;
        //         }
        //
        //         upperRowIndex--;
        //     }
        //     
        //     diagonals.Add(diagonalBuilder.ToString());
        //     diagonalBuilder.Clear();
        // }

        // do the same thing as above starting in the bottom right corner
        // this is the logic for the downward diagonals
        // for (var rowIndex = _input.Length - 1; rowIndex >= 0; rowIndex--)
        // {
        //     var diagonalBuilder = new StringBuilder();
        //     var currentRow = _input[rowIndex];
        //     var startingValue = currentRow[^1];
        //     diagonalBuilder.Append(startingValue);
        //     
        //     var upperRowIndex = rowIndex - 1;
        //     var columnIndex = currentRow.Length - 1;
        //     while (upperRowIndex >= 0)
        //     {
        //         if (columnIndex > 0)
        //         {
        //             var nextValue = _input[upperRowIndex][columnIndex - 1];
        //             diagonalBuilder.Append(nextValue);
        //             columnIndex--;
        //         }
        //         
        //         upperRowIndex--;
        //     }
        //     
        //     diagonals.Add(diagonalBuilder.ToString());
        //     diagonalBuilder.Clear();
        // }
        
        return diagonals;
    }

    // private string BuildUpwardDiagonal(string diagonalStart)
    // {
    //     var diagonalBuilder = new StringBuilder(diagonalStart);
    //
    //     // get up and to the right value, if any
    //     var nextValue = _input[x - 1][y + 1]
    //     diagonalBuilder.Append()
    //     
    //     return diagonalBuilder.ToString();
    // }

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
    IEnumerable<string>? upwardDiagonals = null,
    IEnumerable<string>? downwardDiagonals = null)
{
    public readonly IEnumerable<string> Rows = rows ?? [];
    public readonly IEnumerable<string> Columns = columns ?? [];
    public readonly IEnumerable<string> DownwardDiagonals = downwardDiagonals ?? [];
    public readonly IEnumerable<string> UpwardDiagonals = upwardDiagonals ?? [];
}