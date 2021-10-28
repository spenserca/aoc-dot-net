using AoC._2020;
using FluentAssertions;
using Xunit;

namespace AoC.UnitTests.AoC._2020
{
    public class DayTwoTests
    {
        private readonly DayTwo _underTest;

        public DayTwoTests()
        {
            _underTest = new DayTwo();
        }

        [Fact(DisplayName = "day two part one gets the count of all valid passwords")]
        public void DayTwoPartOne_TestOne()
        {
            var input = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

            var actual = _underTest.PartOne(input);

            actual.Should().Be(2);
        }

        [Fact(DisplayName = "day two part one with puzzle input gets the correct answer")]
        public void DayOnePartOneTest_Two()
        {
            var input = FileReader.ReadAllLines(@"AoC.2020/Data/DayTwo.txt");

            var actual = _underTest.PartOne(input);

            actual.Should().Be(636);
        }
    }
}