using Acmion.GenericEnums;
using BenchmarkDotNet.Attributes;
using GenericEnumsBenchmark.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsBenchmark.Benchmarks
{
    public enum FirstNumberEnum
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }

    public enum SecondNumberEnum
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }

    public class FirstNumberGenericEnum : GenericEnumBase<FirstNumberGenericEnum, int>
    {
        public static readonly FirstNumberGenericEnum Zero = new FirstNumberGenericEnum(0);
        public static readonly FirstNumberGenericEnum One = new FirstNumberGenericEnum(1);
        public static readonly FirstNumberGenericEnum Two = new FirstNumberGenericEnum(2);
        public static readonly FirstNumberGenericEnum Three = new FirstNumberGenericEnum(3);
        public static readonly FirstNumberGenericEnum Four = new FirstNumberGenericEnum(4);
        public static readonly FirstNumberGenericEnum Five = new FirstNumberGenericEnum(5);
        public static readonly FirstNumberGenericEnum Six = new FirstNumberGenericEnum(6);
        public static readonly FirstNumberGenericEnum Seven = new FirstNumberGenericEnum(7);
        public static readonly FirstNumberGenericEnum Eight = new FirstNumberGenericEnum(8);
        public static readonly FirstNumberGenericEnum Nine = new FirstNumberGenericEnum(9);

        public FirstNumberGenericEnum(int value) : base(value) { }
    }

    public class SecondNumberGenericEnum : GenericEnumBase<SecondNumberGenericEnum, int>
    {
        public static readonly SecondNumberGenericEnum Zero = new SecondNumberGenericEnum(0);
        public static readonly SecondNumberGenericEnum One = new SecondNumberGenericEnum(1);
        public static readonly SecondNumberGenericEnum Two = new SecondNumberGenericEnum(2);
        public static readonly SecondNumberGenericEnum Three = new SecondNumberGenericEnum(3);
        public static readonly SecondNumberGenericEnum Four = new SecondNumberGenericEnum(4);
        public static readonly SecondNumberGenericEnum Five = new SecondNumberGenericEnum(5);
        public static readonly SecondNumberGenericEnum Six = new SecondNumberGenericEnum(6);
        public static readonly SecondNumberGenericEnum Seven = new SecondNumberGenericEnum(7);
        public static readonly SecondNumberGenericEnum Eight = new SecondNumberGenericEnum(8);
        public static readonly SecondNumberGenericEnum Nine = new SecondNumberGenericEnum(9);

        public SecondNumberGenericEnum(int value) : base(value) { }
    }

    public class ThirdNumberGenericEnum : GenericEnumBase<ThirdNumberGenericEnum, int>
    {
        public static readonly ThirdNumberGenericEnum Zero = new ThirdNumberGenericEnum(0);
        public static readonly ThirdNumberGenericEnum One = new ThirdNumberGenericEnum(1);
        public static readonly ThirdNumberGenericEnum Two = new ThirdNumberGenericEnum(2);
        public static readonly ThirdNumberGenericEnum Three = new ThirdNumberGenericEnum(3);
        public static readonly ThirdNumberGenericEnum Four = new ThirdNumberGenericEnum(4);
        public static readonly ThirdNumberGenericEnum Five = new ThirdNumberGenericEnum(5);
        public static readonly ThirdNumberGenericEnum Six = new ThirdNumberGenericEnum(6);
        public static readonly ThirdNumberGenericEnum Seven = new ThirdNumberGenericEnum(7);
        public static readonly ThirdNumberGenericEnum Eight = new ThirdNumberGenericEnum(8);
        public static readonly ThirdNumberGenericEnum Nine = new ThirdNumberGenericEnum(9);

        public ThirdNumberGenericEnum(int value) : base(value) { }
    }


    public class EqualityBenchmark
    {
        [Params(3)]
        public int NumberOfEnumsInValue { get; set; }

        [Params(3)]
        public int NumberOfEnumsInComparison { get; set; }

        [Params(3)]
        public int NumberOfEnumsInComparisonOfDifferentType { get; set; }

        public FirstNumberEnum ValueEnum { get; set; } = FirstNumberEnum.Zero;
        public FirstNumberEnum ComparisonEnum { get; set; } = FirstNumberEnum.Zero;
        public SecondNumberEnum ComparisonOfDifferentTypeEnum { get; set; } = SecondNumberEnum.Zero;

        public FirstNumberGenericEnum ValueGenericEnum { get; set; } = FirstNumberGenericEnum.Zero;
        public FirstNumberGenericEnum ComparisonGenericEnum { get; set; } = FirstNumberGenericEnum.Zero;
        public SecondNumberGenericEnum ComparisonOfDifferentTypeGenericEnum { get; set; } = SecondNumberGenericEnum.Zero;
        public ThirdNumberGenericEnum ComparisonOfDifferentTypeAndDifferentValueTypeGenericEnum { get; set; } = ThirdNumberGenericEnum.Zero;

        public EqualityBenchmark() 
        {

        }

        [GlobalSetup]
        public void Setup()
        {
            ValueEnum = FirstNumberEnum.Zero;
            ComparisonEnum = FirstNumberEnum.Zero;

            ValueGenericEnum = FirstNumberGenericEnum.Zero;
            ComparisonGenericEnum = FirstNumberGenericEnum.Zero;
            ComparisonOfDifferentTypeGenericEnum = SecondNumberGenericEnum.Zero;
            ComparisonOfDifferentTypeAndDifferentValueTypeGenericEnum = ThirdNumberGenericEnum.Zero;

            foreach (var n in Enum.GetValues(typeof(FirstNumberEnum)).Cast<FirstNumberEnum>().Skip(1).TakeRandom(NumberOfEnumsInValue))
            {
                ValueEnum |= n;
            }

            foreach (var n in Enum.GetValues(typeof(FirstNumberEnum)).Cast<FirstNumberEnum>().Skip(1).TakeRandom(NumberOfEnumsInComparison))
            {
                ComparisonEnum |= n;
            }

            foreach (var n in FirstNumberGenericEnum.Values.Skip(1).Take(NumberOfEnumsInValue))
            {
                ValueGenericEnum |= n;
            }

            foreach (var n in FirstNumberGenericEnum.Values.Skip(1).Take(NumberOfEnumsInComparison))
            {
                ComparisonGenericEnum |= n;
            }

            foreach (var n in SecondNumberGenericEnum.Values.Skip(1).Take(NumberOfEnumsInComparisonOfDifferentType))
            {
                ComparisonOfDifferentTypeGenericEnum |= n;
            }

            foreach (var n in ThirdNumberGenericEnum.Values.Skip(1).Take(NumberOfEnumsInComparisonOfDifferentType))
            {
                ComparisonOfDifferentTypeAndDifferentValueTypeGenericEnum |= n;
            }
        }

        [Benchmark]
        public bool EnumEquality() => ValueEnum == ComparisonEnum;

        [Benchmark]
        public bool GenericEnumEquality() => ValueGenericEnum == ComparisonGenericEnum;

        [Benchmark]
        public bool GenericEnumOfDifferentTypeEquality() => ValueGenericEnum == ComparisonOfDifferentTypeGenericEnum;

        [Benchmark]
        public bool GenericEnumOfDifferentTypeAndDifferentValueTypeEquality() => ValueGenericEnum == ComparisonOfDifferentTypeAndDifferentValueTypeGenericEnum;
    }
}
