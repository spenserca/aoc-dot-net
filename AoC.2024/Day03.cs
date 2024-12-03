using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2024;

public class Day03 : IDayPartOne
{
    public string Title => "--- Day 3: Mull It Over ---";

    public object PartOne(string[] input)
    {
        return input
            .SelectMany(i => Regex.Matches(i, @"mul\([0-9]{1,3},[0-9]{1,3}\)"))
            .Select(m => new MultiplyInstruction(m.Value))
            .Sum(m => m.Value);
    }
}

public class MultiplyInstruction(string instruction)
{
    public readonly int Value = instruction
        .Replace("mul(", string.Empty)
        .Replace(")", string.Empty)
        .Split(',')
        .Select(int.Parse)
        .Aggregate((x, y) => x * y);
}
