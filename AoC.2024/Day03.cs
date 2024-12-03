using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2024;

public class Day03 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 3: Mull It Over ---";
    private const string MultiplierPattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";

    public object PartOne(string[] input)
    {
        return input
            .SelectMany(i => Regex.Matches(i, MultiplierPattern))
            .Select(m => new MultiplyInstruction(m.Value))
            .Sum(m => m.Value);
    }

    public object PartTwo(string[] input)
    {
        var joined = string.Join(string.Empty, input);

        return ParseMultiplierInstructions(joined).Sum(i => i.Value);
    }

    private static List<MultiplyInstruction> ParseMultiplierInstructions(string instruction)
    {
        var isEnabled = true;

        return Regex
            .Matches(instruction, @"(do\(\))|(don't\(\))|(mul\([0-9]{1,3},[0-9]{1,3}\))")
            .Select(
                (m) =>
                {
                    if (m.Value.Equals("don't()"))
                    {
                        isEnabled = false;
                    }
                    else if (m.Value.Equals("do()"))
                    {
                        isEnabled = true;
                    }
                    else if (Regex.IsMatch(m.Value, MultiplierPattern) && isEnabled)
                    {
                        return new MultiplyInstruction(m.Value);
                    }

                    return MultiplyInstruction.Empty();
                }
            )
            .ToList();
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

    public static MultiplyInstruction Empty() => new("mul(0,0)");
}
