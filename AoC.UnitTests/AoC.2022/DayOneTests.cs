using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class DayOneTests
{
    private DayOne _underTest;

    public DayOneTests()
    {
        _underTest = new DayOne();
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
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/DayOne.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(1);
    }
}