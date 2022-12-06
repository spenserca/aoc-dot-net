using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day01Tests
{
    private readonly Day01 _underTest;
    private const string TestDataFile = @"AoC.2022/Data/Day01.txt";

    public Day01Tests()
    {
        _underTest = new Day01();
    }

    [Fact(DisplayName = "calculates the most calories held by a single elf with test input")]
    public void DayOnePartOne_TestInput()
    {
        var input = new[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(24000);
    }

    [Fact(DisplayName = "calculates the most calories held by a single elf with actual input")]
    public void DayOnePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(69206);
    }

    [Fact(DisplayName = "calculates the total calories held by the elves with the top 3 most calories with test input")]
    public void DayOnePartTwo_TestInput()
    {
        var input = new[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(45000);
    }

    [Fact(DisplayName = "calculates the total calories held by the elves with the top 3 most calories with actual input")]
    public void DayOnePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(197400);
    }
}