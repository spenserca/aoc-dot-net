using System.Text;
using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2024;

public class Day04: IDayPartOne
{
    public string Title => "--- Day 4: Ceres Search ---";
    
    public object PartOne(string[] input)
    {
        var rowMatches = input.Select(i => new WordSearchLine(i).GetNumberOfWordInstances()).Sum();
        var columnMatches = BuildColumns(input).Select(i => new WordSearchLine(i).GetNumberOfWordInstances()).Sum();
        var downwardDiagonalMatches = BuildDownwardDiagonals(input).Select(i => new WordSearchLine(i).GetNumberOfWordInstances()).Sum();
        var upwardDiagonalMatches = BuildUpwardDiagonals(input).Select(i => new WordSearchLine(i).GetNumberOfWordInstances()).Sum();

        return rowMatches + columnMatches + downwardDiagonalMatches + upwardDiagonalMatches;
    }

    private IEnumerable<string> BuildUpwardDiagonals(string[] input)
    {
        return [];
    }

    private IEnumerable<string> BuildDownwardDiagonals(string[] input)
    {
        return [];
    }

    private IEnumerable<string> BuildColumns(string[] input)
    {
        var columns = new List<string>();
        foreach (var row in input)
        {
            var columnBuilder = new StringBuilder();
            foreach (var v in row)
            {
                columnBuilder.Append(v);
            }
            columns.Add(columnBuilder.ToString());
            columnBuilder.Clear();
        }

        return columns;
    }
}

public class Grid(string[] input)
{
    private readonly IEnumerable<string> Rows = input;
    private readonly IEnumerable<string> Columns = BuildColumns(input);
    private readonly IEnumerable<string> DownwardDiagonals = BuildUpwardDiagonals(input);
    private readonly IEnumerable<string> UpwardDiagonals = BuildDownwardDiagonals(input);
    
    private static IEnumerable<string> BuildColumns(string[] input)
    {
        var columns = new List<string>();
        foreach (var row in input)
        {
            var columnBuilder = new StringBuilder();
            foreach (var v in row)
            {
                columnBuilder.Append(v);
            }
            columns.Add(columnBuilder.ToString());
            columnBuilder.Clear();
        }

        return columns;
    }
    
    private static IEnumerable<string> BuildUpwardDiagonals(string[] input)
    {
        return [];
    }

    private static IEnumerable<string> BuildDownwardDiagonals(string[] input)
    {
        return [];
    }
}

public class WordSearchLine(string value)
{
    private const string RegexToSearchFor = @"(XMAS)|(SAMX)";

    public int GetNumberOfWordInstances()
    {
        return Regex.Matches(value, RegexToSearchFor).Count;
    }
}