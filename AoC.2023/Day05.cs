using AoC.Common;

namespace AoC._2023;

public class Day05: IDayPartOne
{
    public string Title => "--- Day 5: If You Give A Seed A Fertilizer ---";

    public object PartOne(string[] input)
    {
        var seedsToPlant = input[0].Split(' ')
            .Where(v => int.TryParse(v, out var value))
            .Select(int.Parse)
            .ToList();
        var maps = new Dictionary<string, SourceDestinationRange>();

        return 0;
    }

    private class SourceDestinationRange
    {
        public Range SourceRange { get; set; }

        public Range DestinationRange { get; set; }
    }
}