using AoC.Common;

namespace AoC._2022;

public class Day10 : IDay
{
    public string Title => "--- Day 10: Cathode-Ray Tube ---";

    public object PartOne(string[] input)
    {
        var totalSignalStrength = 0;
        var registerValue = 1;
        var valueToAdd = 0;
        var interestingCycles = new[]
        {
            20,
            60,
            100,
            140,
            180,
            220
        };
        var cycles = new List<string>();

        foreach (var instruction in input)
        {
            if (instruction == "noop") cycles.Add(instruction);
            else
            {
                cycles.Add(instruction);
                cycles.Add("X");
            }
        }

        for (var i = 1; i <= cycles.Count; i++)
        {
            if (interestingCycles.Contains(i))
            {
                totalSignalStrength += i * registerValue;
            }

            var cycleInstruction = cycles[i - 1];
            if (cycleInstruction == "noop") continue;

            if (cycleInstruction == "X")
            {
                registerValue += valueToAdd;
            }
            else
            {
                var value = int.Parse(cycleInstruction.Split(" ")[1]);
                valueToAdd = value;
            }
        }

        return totalSignalStrength;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}