using AoC._2020;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2020;

public class DayTwoTests
{
    private readonly Day02 _underTest;

    public DayTwoTests()
    {
        _underTest = new Day02();
    }

    [Fact(DisplayName = "day two part one gets the count of all valid passwords")]
    public void DayTwoPartOne_TestOne()
    {
        var input = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(2);
    }

    [Fact(DisplayName = "day two part one with puzzle input gets the correct answer")]
    public void DayTwoPartOne_TestTwo()
    {
        var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayTwo.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(636);
    }

    [Fact(DisplayName = "day two part twi gets the count of all valid passwords")]
    public void DayTwoPartTwo_TestOne()
    {
        var input = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(1);
    }

    [Fact(DisplayName = "day two part two with puzzle input gets the correct answer")]
    public void DayTwoPartTwo_TestTwo()
    {
        var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayTwo.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(588);
    }
}
