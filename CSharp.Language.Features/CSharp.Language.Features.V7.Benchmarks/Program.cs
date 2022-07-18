using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CSharp.Language.Features.V7.Benchmarks.Samples;

namespace CSharp.Language.Features.V7.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<InParameterBenchmarks>();
        }
    }
}
