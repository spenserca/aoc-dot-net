using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DayThreeTests
{
    private readonly Day03 _underTest;

    public DayThreeTests()
    {
        _underTest = new Day03();
    }

    [Fact(DisplayName = "day three part one calculates the power consumption of the submarine")]
    public void DayThreePartOneTest_One()
    {
        var input = new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(198);
    }

    [Fact(DisplayName = "day three part one with puzzle input gets the correct answer")]
    public void DayThreePartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayThree.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(2595824);
    }

    [Fact(DisplayName = "day three part two calculates the life support rating")]
    public void DayThreePartTwoTest_One()
    {
        var input = new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(230);
    }

    [Fact(DisplayName = "day three part two with puzzle input gets the correct answer")]
    public void DayThreePartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayThree.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2135254);
    }
}
