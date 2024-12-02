using AoC._2020;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2020;

public class DayThreeTests
{
    private readonly Day03 _underTest;

    public DayThreeTests()
    {
        _underTest = new Day03();
    }

    [Fact(DisplayName = "day three part one counts all the trees encountered on the way down")]
    public void DayThreePartOne_TestOne()
    {
        var input = new[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(7);
    }

    [Fact(
        DisplayName = "day three part one with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayThreePartOne_TestTwo()
    {
        var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayThree.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(265);
    }
}
