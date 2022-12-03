using AoC.Common;

namespace AoC._2022;

public class DayThree : IDay
{
    public string Title => "--- Day 3: Rucksack Reorganization ---";

    public object PartOne(string[] input)
    {
        var totalPriority = 0;
        
        foreach (var items in input)
        {
            var rucksack = new RuckSack(items);
            totalPriority += rucksack.GetPriority();
        }

        return totalPriority;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private class RuckSack
    {
        private readonly string _compartmentOne;
        private readonly string _compartmentTwo;

        public RuckSack(string items)
        {
            var splitIndex = items.Length / 2;
            _compartmentOne = items[..splitIndex];
            _compartmentTwo = items[splitIndex..];
        }

        public int GetPriority()
        {
            const string priorityList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var item = GetSharedItem();

            return priorityList.IndexOf(item, StringComparison.Ordinal) + 1;
        }

        private string GetSharedItem()
        {
            foreach (var item in _compartmentOne)
            {
                if (_compartmentTwo.Contains(item)) return item.ToString();
            }

            return string.Empty;
        }
    }
}