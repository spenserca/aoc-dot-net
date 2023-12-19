using AoC.Common;

namespace AoC._2023;

public class Day07 : IDayPartOne
{
    public string Title => "--- Day 7: Camel Cards ---";

    public object PartOne(string[] input)
    {
        var hands = new List<Hand>();
        foreach (var i in input)
        {
            var handPieces = i.Split(' ');
            var hand = new Hand(handPieces[0], int.Parse(handPieces[1]));

            hands.Add(hand);
        }

        hands.Sort();

        return hands.Select((h, i) => h.Bid * (i + 1)).Sum();
    }

    private sealed class Hand : IComparable
    {
        private readonly string _cards;
        private const string CardsInOrderOfStrength = "23456789TJQKA";
        public int Bid { get; }

        private HandType Type { get; }

        public Hand(string cards, int bid)
        {
            _cards = cards;
            Bid = bid;
            Type = GetHandType();
        }

        private HandType GetHandType()
        {
            var handCards = new Dictionary<char, int>();
            foreach (var card in _cards)
            {
                if (!handCards.TryAdd(card, 1)) handCards[card]++;
            }

            switch (handCards)
            {
                case { Keys.Count: 5 }: return HandType.HighCard;
                case { Keys.Count: 4 }: return HandType.OnePair;
                case { Keys.Count: 3, Values: var values }:
                    return values.Any(v => v == 3)
                        ? HandType.ThreeOfAKind
                        : HandType.TwoPair;
                case { Keys.Count: 2, Values: var values }:
                    return values.Any(v => v == 4) ? HandType.FourOfAKind : HandType.FullHouse;
                case { Keys.Count: 1 }: return HandType.FiveOfAKind;
                default: throw new ArgumentException("Invalid configuration for cards in the hand!");
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            var objValue = (Hand)obj;
            var typeDiff = Type - objValue.Type;
            if (typeDiff == 0)
            {
                // compare by hand value
                for (var i = 0; i < _cards.Length; i++)
                {
                    var thisCard = _cards[i];
                    var thatCard = objValue._cards[i];

                    if (!thisCard.Equals(thatCard))
                    {
                        var thisCardStrength = CardsInOrderOfStrength.IndexOf(thisCard);
                        var thatCardStrength = CardsInOrderOfStrength.IndexOf(thatCard);

                        return thisCardStrength - thatCardStrength;
                    }
                }
            }

            return typeDiff;
        }
    }

    private enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
}