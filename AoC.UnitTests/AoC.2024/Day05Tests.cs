using System.Collections.Generic;
using System.Linq;
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

    [Theory(DisplayName = "pages to update tests")]
    [InlineData("75,47,61,53,29", true)]
    [InlineData("97,61,53,29,13", true)]
    [InlineData("75,29,13", true)]
    [InlineData("75,97,47,61,53", false)]
    [InlineData("61,13,29", false)]
    [InlineData("97,13,75,29,47", false)]
    public void PagesToUpdateTests(string pages, bool expected)
    {
        var pageOrderingRules = new List<string>()
        {
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
        }.Select(v => new PageOrderingRule(v)).ToList();
        
        var actual = new ListOfPages(pages).IsCorrectlyOrdered(pageOrderingRules);
        
        actual.Should().Be(expected);
    }
}