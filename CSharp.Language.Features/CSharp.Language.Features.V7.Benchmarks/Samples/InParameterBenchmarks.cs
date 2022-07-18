using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using CSharp.Language.Features.V7.Models;
using System;

namespace CSharp.Language.Features.V7.Benchmarks.Samples
{
    [MemoryDiagnoser]
    [NativeMemoryProfiler]
    public class InParameterBenchmarks
    {
        private PointStruct point1;
        private PointStruct point2;

        [Benchmark]
        public void MeasureDistanceBetweenPointsBenchmark() =>
            MeasureDistanceBetweenPoints(point1, point2);

        [Benchmark]
        public double MeasureDistanceBetweenPointsWithInParameterBenchmark() =>
            MeasureDistanceBetweenPointsWithInParameter(point1, point2);

        [GlobalSetup]
        public void SetupBenchmark()
        {
            point1 = new PointStruct(1, 1);
            point2 = new PointStruct(4, 5);
        }

        private double MeasureDistanceBetweenPoints(in PointStruct point1, in PointStruct point2)
        {
            double differenceX = point1.X - point2.X,
                differenceY = point1.Y - point2.Y;

            return Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
        }

        private double MeasureDistanceBetweenPointsWithInParameter(in PointStruct point1, in PointStruct point2)
        {
            double differenceX = point1.X - point2.X,
                differenceY = point1.Y - point2.Y;

            return Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
        }
    }
}
