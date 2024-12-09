using AoC.Common;

namespace AoC._2024;

public class Day05 : IDayPartOne
{
    public string Title => "--- Day 5: Print Queue ---";

    public object PartOne(string[] input)
    {
        var pageOrderingRules = input.Where(v => v.Contains("|"))
            .Select(v => new PageOrderingRule(v)).ToList();
        var pagesToUpdate = input.Where(v => v.Contains(","))
            .Select(v => new PagesToUpdate(v));

        return pagesToUpdate.Where(p => p.IsCorrectlyOrdered(pageOrderingRules))
            .Sum(p => p.MiddlePageNumber);
    }
}

public class PageOrderingRule(string value)
{
    private readonly List<int> _pages = value.Split('|').Select(int.Parse).ToList();
    public int FirstPage => _pages[0];
    public int SecondPage => _pages[1];
    
    public bool IsIncrementingOrder => FirstPage < SecondPage;
}

public class PagesToUpdate(string value)
{
    private readonly List<int> _pages = value.Split(',').Select(int.Parse).ToList();

    public bool IsCorrectlyOrdered(List<PageOrderingRule> rules)
    {
        var pagesAreOrdered = new List<bool>();
        foreach (var rule in rules)
        {
            if (_pages.Contains(rule.FirstPage) && _pages.Contains(rule.SecondPage))
            {
                var firstPageIndex = _pages.IndexOf(rule.FirstPage);       
                var secondPageIndex = _pages.IndexOf(rule.SecondPage);
                if (rule.IsIncrementingOrder)
                {
                    pagesAreOrdered.Add(firstPageIndex < secondPageIndex);
                }

                pagesAreOrdered.Add(firstPageIndex > secondPageIndex);
            }
        }
        return pagesAreOrdered.All(_ => true);
    }

    public int MiddlePageNumber => _pages[_pages.Count / 2];
}