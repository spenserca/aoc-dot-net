using AoC._2022;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2022;

public class Day15Tests
{
    private readonly Day15 _underTest;
    private readonly string[] _actualInput = FileReader.ReadAllLines(@"AoC.2022/Data/Day15.txt");

    public Day15Tests()
    {
        _underTest = new Day15();
    }

    [Fact(DisplayName = "gets the number of locations a beacon CANNOT be in in the row to inspect with test input")]
    public void DayFifteenPartOne_TestInput()
    {
        var input = new[]
        {
            "Sensor at x=2, y=18: closest beacon is at x=-2, y=15",
            "Sensor at x=9, y=16: closest beacon is at x=10, y=16",
            "Sensor at x=13, y=2: closest beacon is at x=15, y=3",
            "Sensor at x=12, y=14: closest beacon is at x=10, y=16",
            "Sensor at x=10, y=20: closest beacon is at x=10, y=16",
            "Sensor at x=14, y=17: closest beacon is at x=10, y=16",
            "Sensor at x=8, y=7: closest beacon is at x=2, y=10",
            "Sensor at x=2, y=0: closest beacon is at x=2, y=10",
            "Sensor at x=0, y=11: closest beacon is at x=2, y=10",
            "Sensor at x=20, y=14: closest beacon is at x=25, y=17",
            "Sensor at x=17, y=20: closest beacon is at x=21, y=22",
            "Sensor at x=16, y=7: closest beacon is at x=15, y=3",
            "Sensor at x=14, y=3: closest beacon is at x=15, y=3",
            "Sensor at x=20, y=1: closest beacon is at x=15, y=3"
        };

        _underTest.RowToInspect = 10;
        var actual = _underTest.PartOne(input);

        actual.Should().Be(26);
    }

    [Fact(DisplayName = "gets the number of locations a beacon CANNOT be in in the row to inspect with actual input")]
    public void DayFifteenPartOne_ActualInput()
    {
        _underTest.RowToInspect = 2000000;
        var actual = _underTest.PartOne(_actualInput);

        actual.Should().Be(26); // 4433028 too low
    }
}