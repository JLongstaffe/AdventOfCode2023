
using Day3.Core;

using NUnit.Framework;

namespace Day3.Tests;

public class Part1Tests
{
    [Test]
    public void SumPartNumbers_returns_correct_sum()
    {
        var input = """
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """;

        Assert.That(Part1.SumPartNumbers(input), Is.EqualTo(4361));
    }
}
