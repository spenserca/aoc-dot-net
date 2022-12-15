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
        var screenLinePosition = 0;
        var valueToAdd = 0;
        var screen = BuildScreen();
        var cycles = BuildCycles(input);
        var screenLineIndex = 0;

        // if the register value (+-1) is equal to the current cycle
        // then draw the sprite

        for (var i = 1; i <= cycles.Count; i++)
        {
            var isRegisterInSpriteRange = registerValue == screenLinePosition - 1 ||
                                          registerValue == screenLinePosition ||
                                          registerValue == screenLinePosition + 1;
            if (isRegisterInSpriteRange)
            {
                var screenLine = screen[screenLineIndex].ToCharArray();
                screenLine[screenLinePosition] = '#';
                screen[screenLineIndex] = string.Join("", screenLine);
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

            // reset screen line position for next line
            if (screenLinePosition == 40)
            {
                screenLineIndex++;
                screenLinePosition = 0;
            }

            screenLinePosition++;
        }

        return screen.ToArray();
    }

    private static List<string> BuildScreen()
    {
        var screenLines = new List<string>()
        {
            "........................................",
            "........................................",
            "........................................",
            "........................................",
            "........................................",
            "........................................",
        };

        return screenLines;
    }
}