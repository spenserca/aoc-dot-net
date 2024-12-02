using AoC._2022;

namespace AoC.UnitTests.AoC._2022;

public class Day08Tests
{
    private readonly Day08 _underTest;
    private const string TestFilePath = @"AoC.2022/Data/Day08.txt";

    public Day08Tests()
    {
        _underTest = new Day08();
    }

    [Fact(
        DisplayName = "finds how many trees are visible from the outside the grid with test input"
    )]
    public void DayEightPartOne_TestInput()
    {
        var input = new[] { "30373", "25512", "65332", "33549", "35390" };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(21);
    }

    [Fact(
        DisplayName = "finds how many trees are visible from the outside the grid with actual input",
        Skip = "input file not included"
    )]
    public void DayEightPartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestFilePath);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(1859);
    }

    [Fact(DisplayName = "finds the highest scenic score with test input")]
    public void DayEightPartTwo_TestInput()
    {
        var input = new[] { "30373", "25512", "65332", "33549", "35390" };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(8);
    }

    [Fact(
        DisplayName = "finds the highest scenic score with actual input",
        Skip = "input file not included"
    )]
    public void DayEightPartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestFilePath);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(332640);
    }
}
