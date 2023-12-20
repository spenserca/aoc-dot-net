using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day03Tests
{
    private readonly Day03 _underTest;
    private const string TestDataFile = @"AoC.2022/Data/Day03.txt";

    public Day03Tests()
    {
        _underTest = new Day03();
    }

    [Fact(
        DisplayName = "calculates the sum of priorities of items included in both compartments with test input"
    )]
    public void DayThreePartOne_TestInput()
    {
        var input = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(157);
    }

    [Fact(
        DisplayName = "calculates the sum of priorities of items included in both compartments with actual input"
    )]
    public void DayThreePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(8085);
    }

    [Fact(
        DisplayName = "calculates the sum of priorities of badges for the elf group with test input"
    )]
    public void DayThreePartTwo_TestInput()
    {
        var input = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(70);
    }

    [Fact(
        DisplayName = "calculates the sum of priorities of badges for the elf group with actual input"
    )]
    public void DayThreePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2515);
    }
}
