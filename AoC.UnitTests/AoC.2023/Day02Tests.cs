using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day02Tests
{
    private readonly Day02 _underTest = new();
    private const string TestDataFile = @"AoC.2023/Data/Day02.txt";

    [Fact(DisplayName = "gets the sum of the ids of games which are possible with test input")]
    public void DayOnePartOne_TestInput()
    {
        var input = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(8);
    }

    [Fact(DisplayName = "gets the sum of the ids of games which are possible with actual input")]
    public void DayOnePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(2449);
    }

    [Fact(DisplayName = "gets the sum of the power of the minimum sets with test input")]
    public void DayOnePartTwo_TestInput()
    {
        var input = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2286);
    }

    [Fact(DisplayName = "gets the sum of the power of the minimum sets with actual input")]
    public void DayOnePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(63981);
    }
}
