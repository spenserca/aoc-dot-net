using AoC.Common;

namespace AoC._2022;

public class Day06 : IDay
{
    public string Title => "--- Day 6: Tuning Trouble ---";

    public object PartOne(string[] input)
    {
        const int numberOfCharsToCheck = 4;
        var value = input[0];
        var charsProcessed = 0;
        for (var i = 0; i < value.Length - (1 + numberOfCharsToCheck); i++)
        {
            var lastFourChars = value.Substring(i, numberOfCharsToCheck);
            var distinctChars = string.Join("", lastFourChars.Distinct());

            if (distinctChars.Length == 4)
            {
                charsProcessed = i + numberOfCharsToCheck;
                break;
            }
        }

        return charsProcessed;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}