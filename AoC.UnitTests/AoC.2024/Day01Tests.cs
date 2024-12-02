using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day01Tests
{
    private readonly Day01 _sut = new();
    private const string TestDataFile = @"AoC.2024/Data/Day01.txt";

    [Fact(DisplayName = "gets the total distance for test input")]
    public void DayOnePartOne_TestInput()
    {
        var input = new[] { "3   4", "4   3", "2   5", "1   3", "3   9", "3   3" };

        var actual = _sut.PartOne(input);

        actual.Should().Be(11);
    }

    [Fact(DisplayName = "gets the total distance for test input", Skip = "input file not included")]
    public void DayOnePartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartOne(input);

        actual.Should().Be(1666427);
    }

    [Fact(DisplayName = "gets the similarity scores for test input")]
    public void DayOnePartTwo_TestInput()
    {
        var input = new[] { "3   4", "4   3", "2   5", "1   3", "3   9", "3   3" };

        var actual = _sut.PartTwo(input);

        actual.Should().Be(31);
    }

    [Fact(
        DisplayName = "gets the similarity scores for test input",
        Skip = "input file not included"
    )]
    public void DayOnePartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartTwo(input);

        actual.Should().Be(24316233);
    }
}
