
using NUnit.Framework;

namespace Day1.Tests;

public class Tests
{
    [Test]
    public void SumCalibrationValues_returns_correct_sum()
    {
        string[] input = [ "1abc2",
                           "pqr3stu8vwx",
                           "a1b2c3d4e5f",
                           "treb7uchet" ];

        Assert.That(CalibrationValues.SumCalibrationValues(input),
                    Is.EqualTo(142));
    }

    [Test]
    public void SumRealCalibrationValues_returns_correct_sum()
    {
        string[] input = [ "two1nine",
                           "eightwothree",
                           "abcone2threexyz",
                           "xtwone3four",
                           "4nineeightseven2",
                           "zoneight234",
                           "7pqrstsixteen",
                           "eightwo" ];

        Assert.That(CalibrationValues.SumRealCalibrationValues(input),
                    Is.EqualTo(363));
    }
}