
using System.Text.RegularExpressions;

namespace Day1;

public static class CalibrationValues
{
    public static int SumCalibrationValues(IEnumerable<string> input) =>
        input.Sum(GetCalibrationValue);

    public static int SumRealCalibrationValues(IEnumerable<string> input) =>
        input.Sum(GetRealCalibrationValue);

    static int GetCalibrationValue(string input)
    {
        var (first, last) = (input.First(char.IsDigit),
                             input.Last(char.IsDigit));

        return int.Parse(new string([first, last]));
    }

    static int GetRealCalibrationValue(string input)
    {
        var digitPattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

        var first = StringToNumber(Regex.Match(input, $"{digitPattern}").Value);

        var last = StringToNumber
            (Regex.Match(input, $".*({digitPattern})").Groups[1].Value);

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
