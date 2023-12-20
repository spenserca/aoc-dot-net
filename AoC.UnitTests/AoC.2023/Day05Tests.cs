using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day05Tests : IDayPartOneTest, IDayPartTwoTest
{
    private readonly Day05 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day05.txt";

    private readonly string[] _testInput =
    {
        "seeds: 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4",
    };

    [Fact(
        DisplayName = "finds the lowest location number that corresponds to any of the initial seeds with test input"
    )]
    public void PartOne_TestInput()
    {
        var actual = _underTest.PartOne(_testInput);

        actual.Should().Be(35);
    }

    [Fact(
        DisplayName = "finds the lowest location number that corresponds to any of the initial seeds with actual input"
    )]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(309796150L);
    }

    [Fact(
        DisplayName = "finds the lowest location number that corresponds to any of the initial seed ranges with test input"
    )]
    public void PartTwo_TestInput()
    {
        var actual = _underTest.PartTwo(_testInput);

        actual.Should().Be(46);
    }

    [Fact(
        DisplayName = "finds the lowest location number that corresponds to any of the initial seed ranges with actual input",
        Skip = "takes too long to process "
    )]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(35);
    }
}
