using Acmion.GenericEnums;
using BenchmarkDotNet.Attributes;
using GenericEnumsBenchmark.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericEnumsBenchmark.Benchmarks
{
    public class Test
    {
        public string X;
        public int BitValue;

        public static int Count;
        public static Dictionary<string, int> BitValDict = new Dictionary<string, int>();
        public static Random Random = new Random();

        public Test(int x) 
        {
            X = x.ToString();

            lock (BitValDict)
            {
                if (BitValDict.TryGetValue(X, out var value2))
                {
                    BitValue = value2;
                }
                else 
                {
                    BitValue = 1 << BitValDict.Count;
                    BitValDict[X] = BitValue;
                }
            }
        }

        public static Func<Test> GetTypeConstructor()
        {
            // Needed, because creates type T! Not type GenericEnum<T, TValue>!

            var type = typeof(Test);
            var valuePropertyType = typeof(int);

            var constructor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { valuePropertyType, }, null);

            if (constructor == null)
            {
                throw new Exception("No constructor found.");
            }

            var constructorExpression = Expression.Lambda<Func<Test>>(Expression.New(constructor, new Expression[]
            {
                Expression.Constant(Random.Next(0, 1000), valuePropertyType),
            }));

            var compiledConstructorExpression = constructorExpression.Compile();

            return compiledConstructorExpression;
        }
    }

    public class TestBenchmark
    {
        public Type TT = typeof(Test);
        public Func<Test> TypeConstructor = Test.GetTypeConstructor();

        public Random Random = new Random();
        public dynamic Index = 10;

        public Dictionary<int, int> TypedDict = new Dictionary<int, int>();
        public Dictionary<dynamic, int> DynamicDict = new Dictionary<dynamic, int>();
        public Dictionary<object, int> ObjectDict = new Dictionary<object, int>();

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < 100; i++) 
            {
                TypedDict[i] = i * i;
                DynamicDict[i] = i * i;
                ObjectDict[i] = i * i;
            }
        }


        /*
        [Benchmark]
        public Test Constructor() => TypeConstructor();

        [Benchmark]
        public object Uninitialized() => FormatterServices.GetUninitializedObject(TT);
        */

        [Benchmark]
        public int TypedDictBench() => TypedDict[Index];

        [Benchmark]
        public int DynamicDictBench() => DynamicDict[Index];

        [Benchmark]
        public int ObjectDictBench() => ObjectDict[Index];
    }
}
