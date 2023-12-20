using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day10Tests
{
    private readonly Day10 _underTest = new();
    private const string TestDataFile = "AoC.2023/Data/Day10.txt";

    [Theory(DisplayName = "gets the steps needed to get farthest from the starting point with test input")]
    [InlineData(new[]
    {
        ".....",
        ".S-7.",
        ".|.|.",
        ".L-J.",
        ".....",
    }, 4)]
    [InlineData(new[]
    {
        "..F7.",
        ".FJ|.",
        "SJ.L7",
        "|F--J",
        "LJ...",
    }, 8)]
    public void PartOne_TestInput(string[] input, int expected)
    {
        var actual = _underTest.PartOne(input);

        actual.Should().Be(expected);
    }

    public void PartOne_ActualInput()
    {
        throw new System.NotImplementedException();
    }
}