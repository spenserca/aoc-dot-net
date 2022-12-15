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
        var cycles = BuildCycles(input);

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

    private static List<string> BuildCycles(IEnumerable<string> input)
    {
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

        return cycles;
    }

    public object PartTwo(string[] input)
    {
        var registerValue = 1;
        var valueToAdd = 0;
        var screen = BuildScreen();
        var cycles = BuildCycles(input);

        for (var i = 1; i <= cycles.Count; i++)
        {
            var row = (i - 1) / 40;
            var column = (i - 1) % 40;

            var shouldDrawSprite = Math.Abs(registerValue - column) <= 1;
            if (shouldDrawSprite)
            {
                var rowValue = screen[row];
                var columns = rowValue.ToCharArray();
                columns[column] = '#';
                screen[row] = string.Join("", columns);
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

        foreach (var line in screen)
        {
            Console.WriteLine(line);
        }

        return screen.ToArray();
    }

    private static List<string> BuildScreen()
    {
        var screenLines = new List<string>()
        {
            "________________________________________",
            "________________________________________",
            "________________________________________",
            "________________________________________",
            "________________________________________",
            "________________________________________",
        };

        return screenLines;
    }
}