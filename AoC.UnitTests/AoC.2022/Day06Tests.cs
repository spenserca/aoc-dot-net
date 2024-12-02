using System.IO;
using AoC._2022;

namespace AoC.UnitTests.AoC._2022;

public class Day06Tests
{
    private readonly Day06 _underTest;
    private const string TestFilePath = @"AoC.2022/Data/Day06.txt";

    public Day06Tests()
    {
        _underTest = new Day06();
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void DaySixPartOne_TestInput(string value, int expected)
    {
        var input = new[] { value };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact(
        DisplayName = "calculates the number of chars processed until 4 unique chars are found in a row with actual input",
        Skip = "input file not included"
    )]
    public void DaySixPartOne_ActualInput()
    {
        var input = File.ReadAllLines(TestFilePath);

        var actual = _underTest.PartOne(input);

        actual.Should().Be(1356);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void DaySixPartTwo_TestInput(string value, int expected)
    {
        var input = new[] { value };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(expected);
    }

    [Fact(
        DisplayName = "calculates the number of chars processed until 14 unique chars are found in a row with actual input",
        Skip = "input file not included"
    )]
    public void DaySixPartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestFilePath);

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2564);
    }
}
