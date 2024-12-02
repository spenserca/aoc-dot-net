using AoC._2021;

namespace AoC.UnitTests.AoC._2021;

public class DayFourTests
{
    private readonly Day04 _underTest;

    public DayFourTests()
    {
        _underTest = new Day04();
    }

    [Fact(DisplayName = "day four part one multiplies the bingo score by the winning number")]
    public void DayFourPartOneTest_One()
    {
        var input = new[]
        {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            "8  2 23  4 24",
            "21  9 14 16  7",
            "6 10  3 18  5",
            "1 12 20 15 19",
            "",
            "3 15  0  2 22",
            "9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            "2  0 12  3  7"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(4512);
    }

    [Fact(
        DisplayName = "day four part one with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayFourPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayFour.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(55770);
    }

    [Fact(
        DisplayName = "day four part two multiplies the bingo score by the winning number of the last winning card"
    )]
    public void DayFourPartTwoTest_One()
    {
        var input = new[]
        {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            "8  2 23  4 24",
            "21  9 14 16  7",
            "6 10  3 18  5",
            "1 12 20 15 19",
            "",
            "3 15  0  2 22",
            "9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            "2  0 12  3  7"
        };

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(1924);
    }

    [Fact(
        DisplayName = "day four part two with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayFourPartTwoTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayFour.txt");

        var actual = _underTest.PartTwo(input);

        actual.Should().Be(2980);
    }
}
