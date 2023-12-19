using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day07Tests : IDayPartOneTest
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

    [Fact(DisplayName = "gets the total winnings for a list of hands with actual input")]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(6440);
    }
}