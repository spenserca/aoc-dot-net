using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021;

public class DaySixTests
{
    private readonly DaySix _underTest;

    public DaySixTests()
    {
        _underTest = new DaySix();
    }

    [Fact(DisplayName = "day six part one calculates the number of lanternfish after 80 days")]
    public void DaySixPartOneTest_One()
    {
        var input = new[]
        {
            "3",
            "4",
            "3",
            "1",
            "2"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(5934);
    }

    [Fact(DisplayName = "day six part one with puzzle input gets the correct answer")]
    public void DaySixPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySix.txt");
    
        var actual = _underTest.PartOne(input);
    
        actual.Should().Be(345793);
    }
    
    // [Fact(DisplayName =
    //     "day six part two counts the number of points that are overlapped by 2+ lines including diagonals")]
    // public void DaySixPartTwoTest_One()
    // {
    //     var input = new[]
    //     {
    //         "0,9 -> 5,9",
    //         "8,0 -> 0,8",
    //         "9,4 -> 3,4",
    //         "2,2 -> 2,1",
    //         "7,0 -> 7,4",
    //         "6,4 -> 2,0",
    //         "0,9 -> 2,9",
    //         "3,4 -> 1,4",
    //         "0,0 -> 8,8",
    //         "5,5 -> 8,2"
    //     };
    //
    //     var actual = _underTest.PartTwo(input);
    //
    //     actual.Should().Be(12);
    // }
    //
    // [Fact(DisplayName = "day six part two with puzzle input gets the correct answer")]
    // public void DaySixPartTwoTest_Two()
    // {
    //     var input = FileReader.ReadAllLines(@"AoC.2021/Data/DaySix.txt");
    //
    //     var actual = _underTest.PartTwo(input);
    //
    //     actual.Should().Be(19663);
    // }
}