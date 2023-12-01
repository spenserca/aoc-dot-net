using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day01Tests
{
    private readonly Day01 _underTest = new();
    private const string TestDataFile = @"AoC.2023/Data/Day01.txt";

    [Fact(DisplayName = "gets the sum of the calibration values for each line with test input")]
    public void DayOnePartOne_TestInput()
    {
        var input = new[]
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(142);
    }

    [Fact(DisplayName = "gets the sum of the calibration values for each line with actual input")]
    public void DayOnePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(54916);
    }

    [Fact(DisplayName = "gets the sum of the calibration values for each line with test input")]
    public void DayOnePartTwo_TestInput()
    {
        var input = new[]
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(281);
    }

    [Fact(DisplayName = "gets the sum of the calibration values for each line with actual input")]
    public void DayOnePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(54728);
    }
}