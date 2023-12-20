using AoC.Common;

namespace AoC._2023;

public class Day04 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 4: Scratchcards ---";

    public object PartOne(string[] input)
    {
        return input
            .Select(i => i.Substring(i.IndexOf(':') + 2))
            .Select(g =>
            {
                var card = g.Split('|').Select(c => c.Trim()).ToList();

                var winningNumbers = card[0]
                    .Split(' ')
                    .Where(v => int.TryParse(v, out _))
                    .Select(int.Parse);
                var myNumbers = card[1]
                    .Split(' ')
                    .Where(v => int.TryParse(v, out _))
                    .Select(int.Parse);

                var overlap = myNumbers.Count(n => winningNumbers.Contains(n));

                if (overlap == 0)
                    return 0;
                if (overlap == 1)
                    return 1;

                return (int)Math.Pow(2, overlap - 1);
            })
            .Sum();
    }

    public object PartTwo(string[] input)
    {
        return input
            .Select((i, index) => i.Substring(i.IndexOf(':') + 2))
            .Select((g, index) => new ScratchCard(input[index], index))
            .ToList()
            .Sum(c => c.GetCountOfAllCardsWon(input));
    }

    private class ScratchCard
    {
        private int Index { get; }

        private IEnumerable<int> WinningNumbers { get; }

        private IEnumerable<int> CardNumbers { get; }

        private int CountOfMatchedNumbers { get; }

        public ScratchCard(string card, int index)
        {
            Index = index;

            var cardSplit = card.Split('|').Select(c => c.Trim()).ToList();

            WinningNumbers = cardSplit[0]
                .Split(' ')
                .Where(v => int.TryParse(v, out _))
                .Select(int.Parse);

            CardNumbers = cardSplit[1]
                .Split(' ')
                .Where(v => int.TryParse(v, out _))
                .Select(int.Parse);

            CountOfMatchedNumbers = CardNumbers.Count(c => WinningNumbers.Contains(c));
        }

        public int GetCountOfAllCardsWon(string[] input)
        {
            const int countForCurrentCard = 1;
            var countOfCardsWonFromBonusCards = 0;
            for (var i = 0; i < CountOfMatchedNumbers; i++)
            {
                var indexOfNextWonCard = Index + 1 + i;
                var cardsWonFromBonusCard = new ScratchCard(
                    input[indexOfNextWonCard],
                    indexOfNextWonCard
                );
                countOfCardsWonFromBonusCards += cardsWonFromBonusCard.GetCountOfAllCardsWon(input);
            }

            return countForCurrentCard + countOfCardsWonFromBonusCards;
        }
    }
}
