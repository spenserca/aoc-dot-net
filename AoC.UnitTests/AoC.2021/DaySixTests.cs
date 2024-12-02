using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DaySixTests
{
    private readonly Day06 _underTest;

    public DaySixTests()
    {
        _underTest = new Day06();
    }

    [Fact(DisplayName = "day six part one calculates the number of lanternfish after 80 days")]
    public void DaySixPartOneTest_One()
    {
        var input = new[] { "3", "4", "3", "1", "2" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(5934);
    }

    [Fact(
        DisplayName = "day six part one with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DaySixPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySix.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(345793);
    }

    [Fact(DisplayName = "day six part two calculates the number of lanternfish after 256 days")]
    public void DaySixPartTwoTest_One()
    {
        var input = new[] { "3", "4", "3", "1", "2" };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(26984457539);
    }

    [Fact(
        DisplayName = "day six part two with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DaySixPartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySix.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(1572643095893L);
    }
}
