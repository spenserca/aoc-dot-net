using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class DayThreeTests
{
    private readonly DayThree _underTest;
    private const string TestDataFile = @"AoC.2022/Data/DayThree.txt";

    public DayThreeTests()
    {
        _underTest = new DayThree();
    }

    [Fact(DisplayName = "calculates the sum of priorities of items included in both compartments with test input")]
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
    
    [Fact(DisplayName = "calculates the sum of priorities of items included in both compartments with actual input")]
    public void DayThreePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(157);
    }
}