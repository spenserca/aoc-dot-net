using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day03Tests
{
    private readonly Day03 _sut = new();
    private const string TestDataFile = @"AoC.2024/Data/Day03.txt";

    [Fact(DisplayName = "2024 day 03 part 01 with test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
        };

        var actual = _sut.PartOne(input);

        actual.Should().Be(161);
    }

    [Fact(DisplayName = "2024 day 03 part 01 with actual input", Skip = "input file not included")]
    public void PartOne_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartOne(input);

        actual.Should().Be(183380722);
    }

    [Fact(DisplayName = "2024 day 03 part 02 with test input")]
    public void PartTwo_TestInput()
    {
        var input = new[]
        {
            "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
        };

        var actual = _sut.PartTwo(input);

        actual.Should().Be(48);
    }

    [Fact(DisplayName = "2024 day 03 part 02 with actual input", Skip = "input file not included")]
    public void PartTwo_ActualInput()
    {
        var input = FileReader.ReadAllLines(TestDataFile);

        var actual = _sut.PartTwo(input);

        actual.Should().Be(82733683);
    }
}
