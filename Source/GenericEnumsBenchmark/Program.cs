using Acmion.GenericEnums;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using GenericEnumsBenchmark.Benchmarks;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace GenericEnumsBenchmark
{
    class Program
    {
        public static string RootPath { get; } = GetRootPath();

        static void Main(string[] args)
        {
            var genericEnumsVersion = typeof(GenericEnum).Assembly.GetName().Version.ToString();
            var config = DefaultConfig.Instance.WithArtifactsPath(RootPath + "/BenchmarksResults/" + genericEnumsVersion)
                                               .DontOverwriteResults();

            //BenchmarkRunner.Run<ReferenceEqualityBenchmark>(config);
            BenchmarkRunner.Run<EqualityBenchmark>(config);
        }

        private static string GetRootPath([CallerFilePath] string sourceFilePath = "")
        {
            return Path.GetDirectoryName(sourceFilePath)!.Replace('\\', '/');
        }
    }
}
