
using BenchmarkDotNet.Attributes;

using Day1.Core;

namespace Day1.Benchmarks;

public class Benchmarks
{
    [Benchmark]
    public void BenchmarkPart1() => Part1.SumCalibrationValues
        (File.ReadAllLines("input.txt"));

    [Benchmark]
    public void BenchmarkPart2() => Part2.SumCalibrationValues
        (File.ReadAllLines("input.txt"));
}
