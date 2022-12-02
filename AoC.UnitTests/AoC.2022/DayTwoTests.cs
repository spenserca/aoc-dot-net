using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class DayTwoTests
{
    private readonly DayTwo _underTest;
    private const string TestDataFile = @"AoC.2022/Data/DayTwo.txt";

    public DayTwoTests()
    {
        _underTest = new DayTwo();
    }

    [Fact(DisplayName = "calculates total score by following the strategy guide with test input")]
    public void DayTwoPartOne_TestInput()
    {
        var input = new[]
        {
            "A Y",
            "B X",
            "C Z"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(15);
    }

    [Fact(DisplayName = "calculates total score by following the strategy guide with actual input")]
    public void DayTwoPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(12458);
    }
}