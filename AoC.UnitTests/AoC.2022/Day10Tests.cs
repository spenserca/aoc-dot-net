using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day10Tests
{
    private readonly Day10 _underTest;

    private readonly string[] _testInput =
    {
        "addx 15",
        "addx -11",
        "addx 6",
        "addx -3",
        "addx 5",
        "addx -1",
        "addx -8",
        "addx 13",
        "addx 4",
        "noop",
        "addx -1",
        "addx 5",
        "addx -1",
        "addx 5",
        "addx -1",
        "addx 5",
        "addx -1",
        "addx 5",
        "addx -1",
        "addx -35",
        "addx 1",
        "addx 24",
        "addx -19",
        "addx 1",
        "addx 16",
        "addx -11",
        "noop",
        "noop",
        "addx 21",
        "addx -15",
        "noop",
        "noop",
        "addx -3",
        "addx 9",
        "addx 1",
        "addx -3",
        "addx 8",
        "addx 1",
        "addx 5",
        "noop",
        "noop",
        "noop",
        "noop",
        "noop",
        "addx -36",
        "noop",
        "addx 1",
        "addx 7",
        "noop",
        "noop",
        "noop",
        "addx 2",
        "addx 6",
        "noop",
        "noop",
        "noop",
        "noop",
        "noop",
        "addx 1",
        "noop",
        "noop",
        "addx 7",
        "addx 1",
        "noop",
        "addx -13",
        "addx 13",
        "addx 7",
        "noop",
        "addx 1",
        "addx -33",
        "noop",
        "noop",
        "noop",
        "addx 2",
        "noop",
        "noop",
        "noop",
        "addx 8",
        "noop",
        "addx -1",
        "addx 2",
        "addx 1",
        "noop",
        "addx 17",
        "addx -9",
        "addx 1",
        "addx 1",
        "addx -3",
        "addx 11",
        "noop",
        "noop",
        "addx 1",
        "noop",
        "addx 1",
        "noop",
        "noop",
        "addx -13",
        "addx -19",
        "addx 1",
        "addx 3",
        "addx 26",
        "addx -30",
        "addx 12",
        "addx -1",
        "addx 3",
        "addx 1",
        "noop",
        "noop",
        "noop",
        "addx -9",
        "addx 18",
        "addx 1",
        "addx 2",
        "noop",
        "noop",
        "addx 9",
        "noop",
        "noop",
        "noop",
        "addx -1",
        "addx 2",
        "addx -37",
        "addx 1",
        "addx 3",
        "noop",
        "addx 15",
        "addx -21",
        "addx 22",
        "addx -6",
        "addx 1",
        "noop",
        "addx 2",
        "addx 1",
        "noop",
        "addx -10",
        "noop",
        "noop",
        "addx 20",
        "addx 1",
        "addx 2",
        "addx 2",
        "addx -6",
        "addx -11",
        "noop",
        "noop",
        "noop",
    };

    public Day10Tests()
    {
        _underTest = new Day10();
    }

    [Fact(DisplayName = "calculates total signal strength with test input")]
    public void DayTenPartOne_TestInput()
    {
        var actual = _underTest.PartOne(_testInput);

        actual.Should().Be(13140);
    }

    [Fact(
        DisplayName = "calculates total signal strength with actual input",
        Skip = "input file not included"
    )]
    public void DayTenPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day10.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(15880);
    }

    [Fact(DisplayName = "draws the correct image with test input")]
    public void DayTenPartTwo_TestInput()
    {
        var expected = new[]
        {
            "##__##__##__##__##__##__##__##__##__##__",
            "###___###___###___###___###___###___###_",
            "####____####____####____####____####____",
            "#####_____#####_____#####_____#####_____",
            "######______######______######______####",
            "#######_______#######_______#######_____"
        };

        var actual = _underTest.PartTwo(_testInput);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(
        DisplayName = "draws the correct image with actual input",
        Skip = "input file not included"
    )]
    public void DayTenPartTwo_ActualInput()
    {
        var expected = new[]
        {
            "###__#_____##__####_#__#__##__####__##__",
            "#__#_#____#__#_#____#_#__#__#____#_#__#_",
            "#__#_#____#____###__##___#__#___#__#____",
            "###__#____#_##_#____#_#__####__#___#_##_",
            "#____#____#__#_#____#_#__#__#_#____#__#_",
            "#____####__###_#____#__#_#__#_####__###_"
        };

        var input = FileReader.ReadAllLines(@"AoC.2022/Data/Day10.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().BeEquivalentTo(expected); // PLGFKAZG
    }
}
