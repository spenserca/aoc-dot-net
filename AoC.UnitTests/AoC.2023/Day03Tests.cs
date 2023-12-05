using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day03Tests
{
    private readonly Day03 _underTest = new();
    private const string TestDataFile = @"AoC.2023/Data/Day03.txt";

    [Fact(DisplayName = "gets the sum of part numbers that are adjacent to a symbol with test input")]
    public void DayOnePartOne_TestInput()
    {
        var input = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(4361);
    }

    [Fact(DisplayName = "gets the sum of part numbers that are adjacent to a symbol with actual input")]
    public void DayOnePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);
    
        var actual = _underTest.PartOne(input);
    
        actual.Should().Be(551094);
    }
    
    [Fact(DisplayName = "gets the sum of the gear ratios with test input")]
    public void DayOnePartTwo_TestInput()
    {
        var input = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };
    
        var actual = _underTest.PartTwo(input);
    
        actual.Should().Be(467835);
    }
    
    // [Fact(DisplayName = "gets the sum of the gear ratios with actual input")]
    // public void DayOnePartTwo_ActualInput()
    // {
    //     var input = FileReader.ReadAllLines(TestDataFile);
    //
    //     var actual = _underTest.PartTwo(input);
    //
    //     actual.Should().Be(63981);
    // }
}