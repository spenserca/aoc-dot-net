using System.Reflection.Metadata;
using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day08Tests : IDayPartOneTest
{
    private readonly Day08 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day08.txt";

    [Fact(DisplayName = "gets the number of steps needed to get to ZZZ with first test input")]
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
}