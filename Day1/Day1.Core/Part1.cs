
namespace Day1;

public static class Part1
{
    public static int SumCalibrationValues(IEnumerable<string> input) =>
        input.Sum(GetCalibrationValue);

    static int GetCalibrationValue(string input)
    {
        var (first, last) = (input.First(char.IsDigit),
                             input.Last(char.IsDigit));

        return int.Parse(new string([first, last]));
    }
}
