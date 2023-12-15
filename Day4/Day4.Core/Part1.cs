
using System.Text.RegularExpressions;

namespace Day4.Core;

public static class Part1
{
    public static int SumPoints(string input) => input.Split('\n').Sum(GetPoints);

    private static int GetPoints(string line)
    {
        var match = Regex.Match(line, @":(.*)\|(.*)");

        var winning = Regex.Matches(match.Groups[1].Value, @"\d+")
                           .Select(m => int.Parse(m.Value));

        var cards = Regex.Matches(match.Groups[2].Value, @"\d+")
                         .Select(m => int.Parse(m.Value));

        return (int) Math.Pow(2, cards.Intersect(winning).Count() - 1);
    }
}
