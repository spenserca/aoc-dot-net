using AoC.Common;

namespace AoC._2023;

public class Day05 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 5: If You Give A Seed A Fertilizer ---";

    public object PartOne(string[] input)
    {
        var seedsToPlant = input[0]
            .Split(' ')
            .Where(v => long.TryParse(v, out _))
            .Select(long.Parse)
            .ToList();
        var almanac = BuildAlmanac(input);

        var lowestLocation = GetLowestLocation(seedsToPlant, almanac);

        return lowestLocation;
    }

    private static long GetLowestLocation(
        List<long> seedsToPlant,
        Dictionary<string, List<SourceDestinationMapping>> almanac
    )
    {
        var lowestLocation = long.MaxValue;
        foreach (var seed in seedsToPlant)
        {
            var soil = GetDestinationValue(almanac["seed-to-soil map:"], seed);

            var fertilizer = GetDestinationValue(almanac["soil-to-fertilizer map:"], soil);

            var water = GetDestinationValue(almanac["fertilizer-to-water map:"], fertilizer);

            var light = GetDestinationValue(almanac["water-to-light map:"], water);

            var temp = GetDestinationValue(almanac["light-to-temperature map:"], light);

            var humidity = GetDestinationValue(almanac["temperature-to-humidity map:"], temp);

            var location = GetDestinationValue(almanac["humidity-to-location map:"], humidity);

            if (location < lowestLocation)
                lowestLocation = location;
        }

        return lowestLocation;
    }

    private static Dictionary<string, List<SourceDestinationMapping>> BuildAlmanac(string[] input)
    {
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
                var rangeStartsAndLength = value.Split(' ').Select(long.Parse).ToArray();

                var sourceStart = rangeStartsAndLength[1];
                var destinationStart = rangeStartsAndLength[0];
                var rangeLength = rangeStartsAndLength[2];
                sourceDestinationMappings.Add(
                    new SourceDestinationMapping()
                    {
                        SourceStart = sourceStart,
                        SourceEnd = sourceStart + rangeLength - 1,
                        DestinationStart = destinationStart,
                        DestinationEnd = destinationStart + rangeLength - 1
                    }
                );
            }
        }

        return maps;
    }

    private static long GetDestinationValue(List<SourceDestinationMapping> maps, long lookupValue)
    {
        var sourceDestinationMapping = maps.FirstOrDefault(
            v => v.SourceStart <= lookupValue && v.SourceEnd >= lookupValue
        );
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

    public object PartTwo(string[] input)
    {
        var seedRangeValues = input[0]
            .Split(' ')
            .Where(v => long.TryParse(v, out _))
            .Select(long.Parse)
            .ToList();

        var almanac = BuildAlmanac(input);

        var lowestLocation = long.MaxValue;
        for (int i = 0; i < seedRangeValues.Count; i++)
        {
            if (i % 2 != 0)
            {
                var seedRange = new List<long>();
                var start = seedRangeValues[i - 1];
                var length = seedRangeValues[i];
                for (int j = 0; j < length; j++)
                {
                    seedRange.Add(start + j);
                }

                var currentLowestLocation = GetLowestLocation(seedRange, almanac);
                if (currentLowestLocation < lowestLocation)
                    lowestLocation = currentLowestLocation;
            }
        }

        return lowestLocation;
    }
}
