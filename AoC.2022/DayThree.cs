using System.Text;
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
            var distinctItemsByCompartment = GetRuckSackItemsDistinctByCompartment(items);
            var sharedItem = GetSharedItem(distinctItemsByCompartment);
            
            totalPriority += CalculatePriority(sharedItem);
        }

        return totalPriority;
    }

    private static string GetRuckSackItemsDistinctByCompartment(string items)
    {
        var splitIndex = items.Length / 2;
        var distinctItemsInCompartmentOne = string.Join("", items[..splitIndex].Distinct());
        var distinctItemsInCompartmentTwo = string.Join("", items[splitIndex..].Distinct());
        return distinctItemsInCompartmentOne + distinctItemsInCompartmentTwo;
    }

    private static string GetSharedItem(string items)
    {
        foreach (var item in items)
        {
            if (items.Count(i => i == item) == 2) return item.ToString();
        }
        
        throw new ArgumentException("No item found that matches criteria for shared items!", nameof(items));
    }

    public object PartTwo(string[] input)
    {
        var badgePriority = 0;
        var currentElfGroupItems = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            var distinctItems = string.Join("", input[i].Distinct());
            currentElfGroupItems.Append(distinctItems);

            if (IsLastElfInGroup(i))
            {
                var badgeItem = GetBadgeItem(currentElfGroupItems.ToString());
                badgePriority += CalculatePriority(badgeItem);

                currentElfGroupItems.Clear();
            }
        }
        
        return badgePriority;
    }

    private static int CalculatePriority(string item)
    {
        const string priorityList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return priorityList.IndexOf(item, StringComparison.Ordinal) + 1;
    }

    private static string GetBadgeItem(string items)
    {
        foreach (var item in items)
        {
            if (items.Count(i => i == item) == 3) return item.ToString();
        }

        throw new ArgumentException("No item found that matches criteria for badge items!", nameof(items));
    }

    private static bool IsLastElfInGroup(int i)
    {
        return (i + 1) % 3 == 0;
    }
}