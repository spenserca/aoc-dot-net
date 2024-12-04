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

        return new Program(joined).Execute();
    }
}

public class Program(string instructions)
{
    private const string MultiplierPattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
    private bool IsEnabled { get; set; } = true;

    private List<MultiplyInstruction> Instructions { get; set; } = new();

    public int Execute()
    {
        var parsedInstructions = Regex.Matches(
            instructions,
            @"(do\(\))|(don't\(\))|(mul\([0-9]{1,3},[0-9]{1,3}\))"
        );

        foreach (Match pi in parsedInstructions)
        {
            ExecuteDontInstruction(pi.Value);
            ExecuteDoInstruction(pi.Value);
            ExecuteMulInstruction(pi.Value);
        }

        return Instructions.Sum(i => i.Value);
    }

    private void ExecuteDoInstruction(string instruction)
    {
        if (instruction.Equals("do()"))
        {
            IsEnabled = true;
        }
    }

    private void ExecuteDontInstruction(string instruction)
    {
        if (instruction.Equals("don't()"))
        {
            IsEnabled = false;
        }
    }

    private void ExecuteMulInstruction(string instruction)
    {
        if (Regex.IsMatch(instruction, MultiplierPattern) && IsEnabled)
        {
            Instructions.Add(new MultiplyInstruction(instruction));
        }
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
