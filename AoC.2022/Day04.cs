using AoC.Common;

namespace AoC._2022;

public class Day04 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 4: Camp Cleanup ---";

    public object PartOne(string[] input)
    {
        var totalRangesContainingOtherRange = 0;

        foreach (var elfPairs in input)
        {
            var rawRanges = elfPairs.Split(',');
            var rangeOne = ParseRange(rawRanges[0]);
            var rangeTwo = ParseRange(rawRanges[1]);

            if (rangeOne.ContainsAllOf(rangeTwo) || rangeTwo.ContainsAllOf(rangeOne))
                totalRangesContainingOtherRange++;
        }

        return totalRangesContainingOtherRange;
    }

    public object PartTwo(string[] input)
    {
        var totalRangesContainingPartOfOtherRange = 0;

        foreach (var elfPairs in input)
        {
            var rawRanges = elfPairs.Split(',');
            var rangeOne = ParseRange(rawRanges[0]);
            var rangeTwo = ParseRange(rawRanges[1]);

            if (rangeOne.ContainsPartOf(rangeTwo) || rangeTwo.ContainsPartOf(rangeOne))
                totalRangesContainingPartOfOtherRange++;
        }

        return totalRangesContainingPartOfOtherRange;
    }

    private static Range ParseRange(string rawRange)
    {
        var rangeValues = rawRange.Split('-');

        return new Range(int.Parse(rangeValues[0]), int.Parse(rangeValues[1]));
    }
}

public static class RangeExtensions
{
    public static bool ContainsAllOf(this Range a, Range b)
    {
        return a.Start.Value <= b.Start.Value && a.End.Value >= b.End.Value;
    }

    public static bool ContainsPartOf(this Range a, Range b)
    {
        return (b.Start.Value >= a.Start.Value && b.Start.Value <= a.End.Value)
            || (b.End.Value <= a.End.Value && b.End.Value >= a.Start.Value);
    }
}
