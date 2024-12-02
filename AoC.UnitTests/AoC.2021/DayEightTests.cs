using AoC._2021;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace AoC.UnitTests.AoC._2021;

public class DayEightTests
{
    private readonly Day08 _underTest;

    public DayEightTests()
    {
        _underTest = new Day08();
    }

    [Fact(
        DisplayName = "day eight part one calculates the number of times 1, 4, 7 or 8 appear in the output"
    )]
    public void DayEightPartOneTest_One()
    {
        var input = new[]
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        var actual = _underTest.PartOne(input);

        actual.Should().Be(26);
    }

    [Fact(
        DisplayName = "day eight part one with puzzle input gets the correct answer",
        Skip = "input file not included"
    )]
    public void DayEightPartOneTest_Two()
    {
        var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayEight.txt");

        var actual = _underTest.PartOne(input);

        actual.Should().Be(310);
    }

    // [Fact(DisplayName =
    //     "day eight part two calculates the amount of fuel spent aligning the crabs with increasing fuel per step")]
    // public void DayEightPartTwoTest_One()
    // {
    //     var input = new[]
    //     {
    //         "16",
    //         "1",
    //         "2",
    //         "0",
    //         "4",
    //         "2",
    //         "7",
    //         "1",
    //         "2",
    //         "14"
    //     };
    //
    //     var actual = _underTest.PartTwo(input);
    //
    //     actual.Should().Be(168);
    // }
    //
    // [Fact(DisplayName = "day eight part two with puzzle input gets the correct answer")]
    // public void DayEightPartTwoTest_Two()
    // {
    //     var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayEight.txt");
    //
    //     var actual = _underTest.PartTwo(input);
    //
    //     actual.Should().Be(98231647);
    // }
}
