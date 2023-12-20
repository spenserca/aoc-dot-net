using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day08Tests : IDayPartOneTest, IDayPartTwoTest
{
    private readonly Day08 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day08.txt";

    [Fact(DisplayName = "gets the number of steps needed to get to ZZZ with test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(2);
    }

    [Fact(DisplayName = "gets the number of steps needed to get to ZZZ with actual input")]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(19667);
    }

    [Fact(
        DisplayName = "gets the number of steps needed to get to all nodes ending in Z with test input"
    )]
    public void PartTwo_TestInput()
    {
        var input = new[]
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(6);
    }

    [Fact(
        DisplayName = "gets the number of steps needed to get to all nodes ending in Z with actual input"
    )]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(19185263738117L);
    }
}
