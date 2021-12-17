using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DayTwoTests
{
    private readonly DayTwo _underTest;

    public DayTwoTests()
    {
        _underTest = new DayTwo();
    }

    [Fact(DisplayName = "day two part one multiplies the final depth and horizontal position")]
    public void DayTwoPartOneTest_One()
    {
        var input = new[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(150);
    }

    [Fact(DisplayName = "day two part one with puzzle input gets the correct answer")]
    public void DayTwoPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayTwo.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(1989014);
    }

    [Fact(DisplayName =
        "day two part two multiplies the final depth and horizontal position taking into account the aim of the submarine")]
    public void DayTwoPartTwoTest_One()
    {
        var input = new[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(900);
    }

    [Fact(DisplayName = "day two part two with puzzle input gets the correct answer")]
    public void DayTwoPartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayTwo.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2006917119);
    }
}