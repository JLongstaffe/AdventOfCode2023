
using System.Text.RegularExpressions;

namespace Day1;

public static class Part2
{
    public static int SumCalibrationValues(IEnumerable<string> input) =>
        input.Sum(GetCalibrationValue);

    static int GetCalibrationValue(string input)
    {
        var digitPattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

        var first = StringToNumber(Regex.Match(input, digitPattern).Value);

        var last = StringToNumber
            (Regex.Match(input, digitPattern, RegexOptions.RightToLeft)
                  .Value);

        return int.Parse($"{first}{last}");
    }

    private static int StringToNumber(string input)
    {
        return int.TryParse(input, out var digit)
             ? digit
             : WordToDigit[input];
    }

    private static readonly Dictionary<string, int> WordToDigit =
        new()
        {
            { "one",   1 },
            { "two",   2 },
            { "three", 3 },
            { "four",  4 },
            { "five",  5 },
            { "six",   6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine",  9 }
        };
}
