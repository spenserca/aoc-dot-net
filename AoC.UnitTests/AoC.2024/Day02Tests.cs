using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day02Tests
{
    private readonly Day02 _sut = new();
    private const string TestDataFile = @"AoC.2024/Data/Day02.txt";

    [Fact(DisplayName = "2024 day 02 part 01 with test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        var actual = _sut.PartOne(input);

        actual.Should().Be(2);
    }

    [Fact(DisplayName = "2024 day 02 part 01 with actual input", Skip = "input file not included")]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartOne(input);

        actual.Should().Be(321);
    }

    [Fact(DisplayName = "2024 day 02 part 02 with test input")]
    public void PartTwo_TestInput()
    {
        var input = new[]
        {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        var actual = _sut.PartTwo(input);

        actual.Should().Be(4);
    }

    [Fact(DisplayName = "2024 day 02 part 02 with actual input", Skip = "input file not included")]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartTwo(input);

        actual.Should().Be(386);
    }
}
