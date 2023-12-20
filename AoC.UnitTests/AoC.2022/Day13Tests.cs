using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day13Tests
{
    private readonly Day13 _underTest;

    public Day13Tests()
    {
        _underTest = new Day13();
    }

    [Fact(
        DisplayName = "gets a count of all packet pairs that are in the right order with test input"
    )]
    public void DayThirteenPartOne_TestInput()
    {
        var input = new[]
        {
            "[1,1,3,1,1]",
            "[1,1,5,1,1]",
            "",
            "[[1],[2,3,4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(13);
    }
}
