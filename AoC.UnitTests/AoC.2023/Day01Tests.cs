using AoC._2023;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2023;

public class Day01Tests
{
    private readonly Day01 _underTest;
    private const string TestDataFile = @"AoC.2023/Data/Day01.txt";

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
}