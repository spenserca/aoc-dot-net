using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day06Tests: IDayPartOneTest
{
    private readonly Day06 _sut = new();
    
    [Fact(DisplayName = "part one test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };
        
        var actual = _sut.PartOne(input);
        
        actual.Should().Be(41);
    }

    public void PartOne_ActualInput()
    {
        throw new System.NotImplementedException();
    }
}