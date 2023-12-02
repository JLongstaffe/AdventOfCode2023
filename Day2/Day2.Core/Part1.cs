
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

        int ToInt(string s) => int.TryParse(s, out var i) ? i : 0;

        bool IsPossible(Match m) => ToInt(m.Groups["Red"].Value) <= MaxRed
                                 && ToInt(m.Groups["Blue"].Value) <= MaxBlue
                                 && ToInt(m.Groups["Green"].Value) <= MaxGreen;

        return Regex.Matches(game, pattern).All(IsPossible);
    }

    private static int GetGameId(string game)
    {
        return int.Parse(Regex.Match(game, @"\d+").Value);
    }

    private const int MaxRed = 12;

    private const int MaxGreen = 13;

    private const int MaxBlue = 14;
}
