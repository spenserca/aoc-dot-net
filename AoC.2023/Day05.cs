using AoC.Common;

namespace AoC._2023;

public class Day05 : IDayPartOne
{
    public string Title => "--- Day 5: If You Give A Seed A Fertilizer ---";

    public object PartOne(string[] input)
    {
        var seedsToPlant = input[0].Split(' ')
            .Where(v => long.TryParse(v, out _))
            .Select(long.Parse)
            .ToList();
        var maps = new Dictionary<string, List<SourceDestinationMapping>>();

        var mapKey = string.Empty;
        var sourceDestinationMappings = new List<SourceDestinationMapping>();
        for (int i = 2; i < input.Length; i++)
        {
            var value = input[i];

            if (string.IsNullOrEmpty(value) || i == input.Length - 1)
            {
                maps[mapKey] = sourceDestinationMappings;
                sourceDestinationMappings = new List<SourceDestinationMapping>();
            }
            else if (value.IndexOf(':') != -1)
            {
                mapKey = value;
            }
            else
            {
                var rangeStartsAndLength = value.Split(' ')
                    .Select(long.Parse)
                    .ToArray();

                var sourceStart = rangeStartsAndLength[1];
                var destinationStart = rangeStartsAndLength[0];
                var rangeLength = rangeStartsAndLength[2];
                sourceDestinationMappings.Add(new SourceDestinationMapping()
                {
                    SourceStart = sourceStart,
                    SourceEnd = sourceStart + rangeLength - 1,
                    DestinationStart = destinationStart,
                    DestinationEnd = destinationStart + rangeLength - 1
                });
            }
        }

        var lowestLocation = long.MaxValue;
        foreach (var seed in seedsToPlant)
        {
            var soil = GetDestinationValue(maps["seed-to-soil map:"], seed);

            var fertilizer = GetDestinationValue(maps["soil-to-fertilizer map:"], soil);

            var water = GetDestinationValue(maps["fertilizer-to-water map:"], fertilizer);

            var light = GetDestinationValue(maps["water-to-light map:"], water);

            var temp = GetDestinationValue(maps["light-to-temperature map:"], light);

            var humidity = GetDestinationValue(maps["temperature-to-humidity map:"], temp);

            var location = GetDestinationValue(maps["humidity-to-location map:"], humidity);

            if (location < lowestLocation) lowestLocation = location;
        }

        return lowestLocation;
    }

    private static long GetDestinationValue(List<SourceDestinationMapping> maps, long lookupValue)
    {
        var sourceDestinationMapping = maps.FirstOrDefault(v => v.SourceStart <= lookupValue && v.SourceEnd >= lookupValue);
        return sourceDestinationMapping is not null
            ? GetDestinationValue(sourceDestinationMapping, lookupValue)
            : lookupValue;
    }

    private static long GetDestinationValue(SourceDestinationMapping mapping, long lookupValue)
    {
        var sourceDiff = Math.Abs(mapping.SourceStart - lookupValue);
        return mapping.DestinationStart + sourceDiff;
    }

    private class SourceDestinationMapping
    {
        public long SourceStart { get; set; }
        public long SourceEnd { get; set; }

        public long DestinationStart { get; set; }
        public long DestinationEnd { get; set; }
    }
}