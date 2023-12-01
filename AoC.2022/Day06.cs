using AoC.Common;

namespace AoC._2022;

public class Day06 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 6: Tuning Trouble ---";

    public object PartOne(string[] input)
    {
        const int numberOfCharsToCheck = 4;
        var value = input[0];

        return new UniqueSequenceFinder(numberOfCharsToCheck)
            .GetNumberOfCharsProcessedBeforeUniqueSequenceIsFound(value);
    }

    public object PartTwo(string[] input)
    {
        const int numberOfCharsToCheck = 14;
        var value = input[0];

        return new UniqueSequenceFinder(numberOfCharsToCheck)
            .GetNumberOfCharsProcessedBeforeUniqueSequenceIsFound(value);
    }

    private class UniqueSequenceFinder
    {
        private readonly int _numberOfCharsToCheck;

        public UniqueSequenceFinder(int numberOfCharsToCheck)
        {
            _numberOfCharsToCheck = numberOfCharsToCheck;
        }

        public int GetNumberOfCharsProcessedBeforeUniqueSequenceIsFound(string value)
        {
            var charsProcessed = 0;
            for (var i = 0; i < value.Length - (1 + _numberOfCharsToCheck); i++)
            {
                var lastFourChars = value.Substring(i, _numberOfCharsToCheck);
                var distinctChars = string.Join("", lastFourChars.Distinct());

                if (distinctChars.Length == _numberOfCharsToCheck)
                {
                    charsProcessed = i + _numberOfCharsToCheck;
                    break;
                }
            }

            return charsProcessed;
        }
    }
}