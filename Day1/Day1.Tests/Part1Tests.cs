
using Day1.Core;

using NUnit.Framework;

namespace Day1.Tests;

public class Part1Tests
{
    [Test]
    public void SumCalibrationValues_returns_correct_sum()
    {
        string[] input = [ "1abc2",
                           "pqr3stu8vwx",
                           "a1b2c3d4e5f",
                           "treb7uchet" ];

        Assert.That(Part1.SumCalibrationValues(input), Is.EqualTo(142));
    }
}
