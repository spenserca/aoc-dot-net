using AoC._2020;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2020;

public class DayOneTests
{
    private readonly Day01 _underTest;

    public DayOneTests()
    {
        _underTest = new Day01();
    }

    [Fact(
        DisplayName = "day one part one gets the multiplied value of the two numbers that add up to 2020"
    )]
    public void DayOnePartOneTest_One()
    {
        var input = new[] { "1721", "979", "366", "299", "675", "1456" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(514579);
    }

    [Fact(
        DisplayName = "day one part one with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayOnePartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayOne.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(926464);
    }

    [Fact(
        DisplayName = "day one part two gets the multiplied value of the three numbers that add up to 2020"
    )]
    public void DayOnePartTwoTest_One()
    {
        var input = new[] { "1721", "979", "366", "299", "675", "1456" };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(241861950);
    }

    [Fact(
        DisplayName = "day one part two with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayOnePartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayOne.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(65656536);
    }
}
