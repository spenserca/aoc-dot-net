using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day04Tests
{
    private readonly Day04 _underTest = new();
    private const string TestDataFile = @"AoC.2023/Data/Day03.txt";

    [Fact(DisplayName = "gets the total points of all the scratch cards with test input")]
    public void DayFourPartOne_TestInput()
    {
        var input = new[]
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(13);
    }

    [Fact(DisplayName = "gets the total points of all the scratch cards  with actual input", Skip = "wip")]
    public void DayFourPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);
    
        var actual = _underTest.PartOne(input);
    
        actual.Should().Be(551094);
    } 
}