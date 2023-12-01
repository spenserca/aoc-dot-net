using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DayOneTests
{
    private readonly Day01 _underTest;

    public DayOneTests()
    {
        _underTest = new Day01();
    }

    [Fact(DisplayName = "day one part one counts the number of depth increases")]
    public void DayOnePartOneTest_One()
    {
        var input = new[]
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(7);
    }

    [Fact(DisplayName = "day one part one with puzzle input gets the correct answer")]
    public void DayOnePartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayOne.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(1713);
    }

    [Fact(DisplayName = "day one part two counts the number of depth increases in a sliding window")]
    public void DayOnePartTwoTest_One()
    {
        var input = new[]
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(5);
    }

    [Fact(DisplayName = "day one part two with puzzle input gets the correct answer")]
    public void DayOnePartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayOne.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(1734);
    }
}