using BenchmarkDotNet.Running;

namespace Experiments.App
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ComparingStringsAndEnums>();
        }
    }
}
