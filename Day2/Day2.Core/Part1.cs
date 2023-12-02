
using System.Text.RegularExpressions;

namespace Day2.Core;

public static class Part1
{
    public static int SumPossibleGames(IEnumerable<string> input)
    {
        return input.Where(IsGamePossible).Sum(GetGameId);
    }

    private static bool IsGamePossible(string game)
    {
        var pattern = @"(?<Blue>\d+)\sblue|(?<Red>\d+)\sred|(?<Green>\d+)\sgreen";

        var matches = Regex.Matches(game, pattern);

        static int ToInt(string s) => int.TryParse(s, out var i) ? i : 0;

        var reds = matches.Select(m => ToInt(m.Groups["Red"].Value));

        var blues = matches.Select(m => ToInt(m.Groups["Blue"].Value));

        var greens = matches.Select(m => ToInt(m.Groups["Green"].Value));

        return reds.All(x => x <= MaxRed)
            && greens.All(x => x <= MaxGreen)
            && blues.All(x => x <= MaxBlue);
    }

    private static int GetGameId(string game)
    {
        return int.Parse(Regex.Match(game, @"\d+").Value);
    }

    private const int MaxRed = 12;

    private const int MaxGreen = 13;

    private const int MaxBlue = 14;
}
