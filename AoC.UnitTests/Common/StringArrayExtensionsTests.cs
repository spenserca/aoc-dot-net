using AoC.Common;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.Common;

public class StringArrayExtensionsTests
{
    private static readonly string[] TestInput =
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi",
    };

    private static readonly string[] ActualInput = FileReader.ReadAllLines(@"AoC.2022/Data/Day12.txt");

    [Theory(DisplayName = "gets the coordinate position of the value in the actual input")]
    [InlineData('S', 0, 20, 0, false)]
    [InlineData('E', 119, 20, 25, false)]
    [InlineData('S', 0, 0, 0, true)]
    [InlineData('E', 5, 2, 25, true)]
    public void GetPositionOfValue_ReturnsCorrectPositionOfValueFromActualInput(char value, int x, int y, int z,
        bool useTestInput)
    {
        var actual = useTestInput
            ? TestInput.GetPositionOfValue(value, z)
            : ActualInput.GetPositionOfValue(value, z);

        actual.X.Should().Be(x);
        actual.Y.Should().Be(y);
        actual.Z.Should().Be(z);
    }
}