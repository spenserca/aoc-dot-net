using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DaySevenTests
{
    private readonly Day07 _underTest;

    public DaySevenTests()
    {
        _underTest = new Day07();
    }

    [Fact(
        DisplayName = "day seven part one calculates the amount of fuel spent aligning the crabs"
    )]
    public void DaySevenPartOneTest_One()
    {
        var input = new[] { "16", "1", "2", "0", "4", "2", "7", "1", "2", "14" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(37);
    }

    [Fact(DisplayName = "day seven part one with puzzle input gets the correct answer")]
    public void DaySevenPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySeven.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(348996);
    }

    [Fact(
        DisplayName = "day seven part two calculates the amount of fuel spent aligning the crabs with increasing fuel per step"
    )]
    public void DaySevenPartTwoTest_One()
    {
        var input = new[] { "16", "1", "2", "0", "4", "2", "7", "1", "2", "14" };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(168);
    }

    [Fact(DisplayName = "day seven part two with puzzle input gets the correct answer")]
    public void DaySevenPartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySeven.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(98231647);
    }
}
