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
        var badgePriority = 0;
        var currentElfGroupItems = string.Empty;

        for (var i = 0; i < input.Length; i++)
        {
            var distinctItems = string.Join("", input[i].Distinct());
            currentElfGroupItems += distinctItems;

            if (IsLastElfInGroup(i))
            {
                const string priorityList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var badgeItem = GetBadgeItem(currentElfGroupItems);
                badgePriority += priorityList.IndexOf(badgeItem, StringComparison.Ordinal) + 1;
                
                currentElfGroupItems = string.Empty;
            }
        }
        
        return badgePriority;
    }

    private string GetBadgeItem(string items)
    {
        foreach (var item in items)
        {
            if (items.Count(i => i == item) == 3) return item.ToString();
        }

        throw new Exception("No item found that matches criteria for badge items!");
    }

    private static bool IsLastElfInGroup(int i)
    {
        return (i + 1) % 3 == 0;
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