using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsBenchmark.Benchmarks
{
    public class ReferenceEqualityBenchmark
    {
        private static object TestObject0 = new object();
        private static object TestObject1 = TestObject0;

        [Benchmark]
        public bool ReferenceEquality()
        {
            return TestObject0 == TestObject1;
        }
    }
}
