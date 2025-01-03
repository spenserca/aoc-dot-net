using AoC._2022;

namespace AoC.UnitTests.AoC._2022;

public class Day14Tests
{
    private readonly Day14 _underTest;

    public Day14Tests()
    {
        _underTest = new Day14();
    }

    [Fact(
        DisplayName = "determines how many units of sand will fall before endlessly falling into the abyss with test input"
    )]
    public void DayFourteenPartOne_TestInput()
    {
        var input = new[] { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9", };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(24);
    }

    [Fact(
        DisplayName = "determines how many units of sand will fall before endlessly falling into the abyss with actual input",
        Skip = "input file not included"
    )]
    public void DayFourteenPartOne_ActualInput()
    {
        var actual = _underTest.PartOne(FileReader.ReadAllLines(@"AoC.2022/Data/Day14.txt"));

        actual.Should().Be(795);
    }

    [Fact(
        DisplayName = "determines how many units of sand will fall before the flow point is blocked with test input"
    )]
    public void DayFourteenPartTwo_TestInput()
    {
        var input = new[] { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9", };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(93);
    }

    [Fact(
        DisplayName = "determines how many units of sand will fall before the flow point is blocked with actual input",
        Skip = "input file not included"
    )]
    public void DayFourteenPartTwo_ActualInput()
    {
        var actual = _underTest.PartTwo(FileReader.ReadAllLines(@"AoC.2022/Data/Day14.txt"));

        actual.Should().Be(30214);
    }
}
