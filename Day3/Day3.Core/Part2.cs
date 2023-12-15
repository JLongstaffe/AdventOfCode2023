
using System.Text.RegularExpressions;

namespace Day3.Core;

public static class Part2
{
    public static int SumPartNumbers(string input)
    {
        var numbers = input.Split("\n")
                           .SelectMany((l, i) => Regex.Matches(l, @"\d+")
                           .Select(m => (number: m.Value, x: m.Index, y: i)))
                           .ToArray();

        var stars = input.Split("\n")
                         .SelectMany((l, i) => Regex.Matches(l, @"\*")
                         .Select(m => (x: m.Index, y: i)))
                         .ToHashSet();

        IEnumerable<int> TouchedNumbers(int x, int y) => numbers.Where(t =>
        {
            return (t.y >= y - 1 && t.y <= y + 1)
                && (t.x + t.number.Length >= x)
                && (t.x <= x + 1);
        })
        .Select(t => int.Parse(t.number));

        return stars.Select(n => TouchedNumbers(n.x, n.y).ToArray())
                    .Where(n => n.Length is 2)
                    .Sum(n => n[0] * n[1]);
    }
}
