using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day04Tests
{
    private readonly Day04 _sut = new();
    private const string TestDataFile = @"AoC.2024/Data/Day04.txt";

    [Fact(DisplayName = "2024 day 04 part 01 with test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        };

        var actual = _sut.PartOne(input);

        actual.Should().Be(18);
    }
}