using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day11Tests
{
    private readonly Day11 _underTest;

    private readonly string[] _input =
    {
        "Monkey 0:",
        "  Starting items: 79, 98",
        "  Operation: new = old * 19",
        "  Test: divisible by 23",
        "    If true: throw to monkey 2",
        "    If false: throw to monkey 3",
        "",
        "Monkey 1:",
        "  Starting items: 54, 65, 75, 74",
        "  Operation: new = old + 6",
        "  Test: divisible by 19",
        "    If true: throw to monkey 2",
        "    If false: throw to monkey 0",
        "",
        "Monkey 2:",
        "  Starting items: 79, 60, 97",
        "  Operation: new = old * old",
        "  Test: divisible by 13",
        "    If true: throw to monkey 1",
        "    If false: throw to monkey 3",
        "",
        "Monkey 3:",
        "  Starting items: 74",
        "  Operation: new = old + 3",
        "  Test: divisible by 17",
        "    If true: throw to monkey 0",
        "    If false: throw to monkey 1",
    };

    public Day11Tests()
    {
        _underTest = new Day11();
    }

    [Fact(DisplayName = "calculates the total monkey business with test input")]
    public void DayElevenPartOne_TestInput()
    {
        var actual = _underTest.PartOne(_input);

        actual.Should().Be(10605);
    }

    [Fact(DisplayName = "calculates the total monkey business with actual input")]
    public void DayElevenPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day11.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(316888);
    }

    [Fact(DisplayName = "calculates the total monkey business with manually reduced worry levels with test input")]
    public void DayElevenPartTwo_TestInput()
    {
        var actual = _underTest.PartTwo(_input);

        actual.Should().Be(2713310158);
    }

    [Fact(DisplayName = "calculates the total monkey business with manually reduced worry levels with actual input")]
    public void DayElevenPartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day11.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(35270398814L);
    }
}