
using System.Text.RegularExpressions;

namespace Day2.Core;

public static class Part2
{
    public static int SumOfPowers(IEnumerable<string> input)
    {
        return input.Sum(GamePower);
    }

    private static int GamePower(string game)
    {
        var pattern = @"(?<Blue>\d+)\sblue|(?<Red>\d+)\sred|(?<Green>\d+)\sgreen";

        var matches = Regex.Matches(game, pattern);

        static int ToInt(string s) => int.TryParse(s, out var i) ? i : 0;

        var reds = matches.Select(m => ToInt(m.Groups["Red"].Value));

        var blues = matches.Select(m => ToInt(m.Groups["Blue"].Value));

        var greens = matches.Select(m => ToInt(m.Groups["Green"].Value));

        return reds.Max() * greens.Max() * blues.Max();
    }
}
