using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DayFiveTests
{
    private readonly DayFive _underTest;

    public DayFiveTests()
    {
        _underTest = new DayFive();
    }

    [Fact(DisplayName = "day five part one counts the number of points that are overlapped by 2+ lines")]
    public void DayFivePartOneTest_One()
    {
        var input = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(5);
    }

    [Fact(DisplayName = "day five part one with puzzle input gets the correct answer")]
    public void DayFivePartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayFive.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(6548);
    }

    [Fact(DisplayName =
        "day five part two counts the number of points that are overlapped by 2+ lines including diagonals")]
    public void DayFivePartTwoTest_One()
    {
        var input = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(12);
    }

    [Fact(DisplayName = "day five part two with puzzle input gets the correct answer")]
    public void DayFivePartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayFive.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(19663);
    }
}