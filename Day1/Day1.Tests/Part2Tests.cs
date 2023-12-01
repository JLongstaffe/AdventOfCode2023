
using Day1.Core;

using NUnit.Framework;

namespace Day1.Tests;

public class Part2Tests
{
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

        Assert.That(Part2.SumCalibrationValues(input), Is.EqualTo(363));
    }
}
