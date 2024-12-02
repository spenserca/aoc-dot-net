using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day07Tests : IDayPartOneTest, IDayPartTwoTest
{
    private readonly Day07 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day07.txt";

    private readonly string[] _testInput =
    {
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483",
    };

    [Fact(DisplayName = "gets the total winnings for a list of hands with test input")]
    public void PartOne_TestInput()
    {
        var actual = _underTest.PartOne(_testInput);

        actual.Should().Be(6440);
    }

    [Fact(
        DisplayName = "gets the total winnings for a list of hands with actual input",
        Skip = "input file not included"
    )]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(241455695);
    }

    [Fact(
        DisplayName = "gets the total winnings for a list of hands (including jokers) with test input"
    )]
    public void PartTwo_TestInput()
    {
        var actual = _underTest.PartTwo(_testInput);

        actual.Should().Be(5905);
    }

    [Fact(
        DisplayName = "gets the total winnings for a list of hands (including jokers) with actual input",
        Skip = "input file not included"
    )]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(243101568);
    }
}
