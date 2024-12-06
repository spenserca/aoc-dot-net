using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day05Tests
{
    private readonly Day05 _sut = new();
    private const string TestDataFile = @"AoC.2024/Data/Day05.txt";
    private const string SampleDataFile = @"AoC.2024/Samples/Day05.txt";

    [Fact(DisplayName = "2024 day 05 part 01 with test input")]
    public void PartOne_TestInput()
    {
        var input = FileReader.ReadAllLines(SampleDataFile);

        var actual = _sut.PartOne(input);

        actual.Should().Be(143);
    }
}