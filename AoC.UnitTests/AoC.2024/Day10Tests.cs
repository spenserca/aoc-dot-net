using AoC._2024;

namespace AoC.UnitTests.AoC._2024;

public class Day10Tests: IDayPartOneTest
{
    private readonly Day10 _sut = new();
    
    [Fact(DisplayName = "can solve 2024 day 10 with test input")]
    public void PartOne_TestInput()
    {
        var input = new[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        };
        
        var actual = _sut.PartOne(input);

        actual.Should().Be(36);
    }

    public void PartOne_ActualInput()
    {
        throw new System.NotImplementedException();
    }
}