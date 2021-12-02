using AoC._2021;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2021
{
    public class DayOneTests
    {
        private DayOne _underTest;

        public DayOneTests()
        {
            _underTest = new DayOne();
        }

        [Fact(DisplayName = "day one part one does something")]
        public void DayOnePartOneTest_One()
        {
            var input = new[]
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263"
            };

            var actual = _underTest.PartOne(input);

            actual.Should().Be(7);
        }
        
        [Fact(DisplayName = "day one part one with puzzle input gets the correct answer")]
        public void DayOnePartOneTest_Two()
        {
            var input = FileReader.ReadAllLines(@"AoC.2021/Data/DayOne.txt");

            var actual = _underTest.PartOne(input);

            actual.Should().Be(1713);
        }
    }
}