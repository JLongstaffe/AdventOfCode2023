
using System.Text.RegularExpressions;

namespace Day3.Core;

public static class Part1
{
    public static int SumPartNumbers(string input)
    {
        var numbers = input.Split("\n")
                           .SelectMany((l, i) => Regex.Matches(l, @"\d+")
                           .Select(m => (number: m.Value, x: m.Index, y: i)))
                           .ToArray();

        var mines = input.Split("\n")
                         .Select(l => Regex.Matches(l, @"[^\.\d]")
                                     .Select(m => m.Index).ToArray())
                         .ToArray();

        bool Touches(int numberX, int numberY, int numberLength)
        {
            bool rowTouches(int y) => mines[y]
                                     .IsInRange(numberX - 1, numberX + numberLength);

            return (numberY > 0 && rowTouches(numberY - 1))
                || rowTouches(numberY)
                || (numberY < mines.Length - 1 && rowTouches(numberY + 1));

        }

        return numbers.Where(n => Touches(n.x, n.y, n.number.Length))
                      .Select(n => int.Parse(n.number))
                      .Sum();
    }

    private static bool IsInRange(this IEnumerable<int> sorted, int lower, int upper)
    {
        foreach (var i in sorted)
        {
            if (i < lower) continue;

            return i <= upper;
        }

        return false;
    }
}
