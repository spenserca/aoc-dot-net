using AoC.Common;

namespace AoC._2023;

public class Day07 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 7: Camel Cards ---";

    public object PartOne(string[] input)
    {
        var hands = new List<CamelCardHand>();
        foreach (var i in input)
        {
            var handPieces = i.Split(' ');
            var hand = new CamelCardHand(handPieces[0], int.Parse(handPieces[1]));

            hands.Add(hand);
        }

        hands.Sort();

        return hands.Select((h, i) => h.Bid * (i + 1)).Sum();
    }

    public object PartTwo(string[] input)
    {
        var hands = new List<CamelCardHand>();
        foreach (var i in input)
        {
            var handPieces = i.Split(' ');
            var hand = new CamelCardHand(handPieces[0], int.Parse(handPieces[1]), true);

            hands.Add(hand);
        }

        hands.Sort();

        return hands.Select((h, i) => h.Bid * (i + 1)).Sum();
    }
}
