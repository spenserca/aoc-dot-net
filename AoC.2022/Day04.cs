using AoC.Common;

namespace AoC._2022;

public class Day04 : IDay
{
    public string Title => "--- Day 4: Camp Cleanup ---";

    public object PartOne(string[] input)
    {
        var totalRangesContainingOtherRange = 0;

        foreach (var elfPairs in input)
        {
            var rawRanges = elfPairs.Split(',');
            var rawRangeOne = rawRanges[0].Split('-');
            var rangeOne = new Range(int.Parse(rawRangeOne[0]), int.Parse(rawRangeOne[1]));
            var rawRangeTwo = rawRanges[1].Split('-');
            var rangeTwo = new Range(int.Parse(rawRangeTwo[0]), int.Parse(rawRangeTwo[1]));

            if (rangeOne.Contains(rangeTwo) || rangeTwo.Contains(rangeOne))
                totalRangesContainingOtherRange++;
        }

        return totalRangesContainingOtherRange;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}

public static class RangeExtensions
{
    public static bool Contains(this Range a, Range b)
    {
        return a.Start.Value <= b.Start.Value && a.End.Value >= b.End.Value;
    }
}