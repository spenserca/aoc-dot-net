namespace AoC._2023;

internal class CamelCardHand : IComparable
{
    private readonly string _cards;
    private readonly bool _areJokersWild;
    private const string CardsInOrderOfStrength = "J23456789TJQKA";
    public int Bid { get; }

    private HandType Type { get; }

    private bool HasJokers => _cards.Contains('J');

    public CamelCardHand(string cards, int bid, bool areJokersWild = false)
    {
        _cards = cards;
        _areJokersWild = areJokersWild;
        Bid = bid;
        Type = GetHandType();
    }

    private HandType GetHandType()
    {
        return _areJokersWild ? GetHandTypeWithJokersWild() : GetHandTypeWithoutJokersWild();
    }

    private HandType GetHandTypeWithJokersWild()
    {
        if (!HasJokers)
            return GetHandTypeWithoutJokersWild();
        var handCards = new Dictionary<char, int>();
        foreach (var card in _cards)
        {
            if (!handCards.TryAdd(card, 1))
                handCards[card]++;
        }

        return handCards switch
        {
            { Keys.Count: 1 } => HandType.FiveOfAKind,
            { Keys.Count: 2 } => HandType.FiveOfAKind,
            // 3 Jokers
            { Keys.Count: 3 } when handCards['J'] == 3 => HandType.FourOfAKind,
            // 2 Jokers
            { Keys.Count: 3 } when handCards['J'] == 2 => HandType.FourOfAKind,
            { Keys.Count: 4 } when handCards['J'] == 2 => HandType.ThreeOfAKind,
            // 1 Joker
            { Keys.Count: 3 } when handCards['J'] == 1 && handCards.ContainsValue(3)
                => HandType.FourOfAKind,
            { Keys.Count: 3 } when handCards['J'] == 1 && handCards.ContainsValue(2)
                => HandType.FullHouse,
            { Keys.Count: 4 } when handCards['J'] == 1 => HandType.ThreeOfAKind,
            { Keys.Count: 5 } when handCards['J'] == 1 => HandType.OnePair,
            _ => throw new ArgumentException("Invalid configuration for cards in the hand!")
        };
    }

    private HandType GetHandTypeWithoutJokersWild()
    {
        var handCards = new Dictionary<char, int>();
        foreach (var card in _cards)
        {
            if (!handCards.TryAdd(card, 1))
                handCards[card]++;
        }

        return handCards switch
        {
            { Keys.Count: 5 } => HandType.HighCard,
            { Keys.Count: 4 } => HandType.OnePair,
            { Keys.Count: 3, Values: var values }
                => values.Any(v => v == 3) ? HandType.ThreeOfAKind : HandType.TwoPair,
            { Keys.Count: 2, Values: var values }
                => values.Any(v => v == 4) ? HandType.FourOfAKind : HandType.FullHouse,
            { Keys.Count: 1 } => HandType.FiveOfAKind,
            _ => throw new ArgumentException("Invalid configuration for cards in the hand!")
        };
    }

    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;
        var objValue = (CamelCardHand)obj;
        var typeDiff = Type - objValue.Type;

        if (typeDiff != 0)
            return typeDiff;

        for (var i = 0; i < _cards.Length; i++)
        {
            var thisCard = _cards[i];
            var thatCard = objValue._cards[i];

            if (thisCard.Equals(thatCard))
                continue;

            var thisCardStrength = CardsInOrderOfStrength.IndexOf(thisCard);
            var thatCardStrength = CardsInOrderOfStrength.IndexOf(thatCard);

            return thisCardStrength - thatCardStrength;
        }

        return typeDiff;
    }
}

public enum HandType
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}
