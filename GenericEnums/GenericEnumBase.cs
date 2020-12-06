using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Acmion.GenericEnums
{
    public class GenericEnumBase<T, TValue> : GenericEnumValue<TValue>, IEquatable<GenericEnumBase<T, TValue>> where T : GenericEnumBase<T, TValue>
    {
        public static IReadOnlyList<T> Values => LazyValues.Value;

        private static Func<T> TypeConstructor { get; } = GetTypeConstructor();
        private static List<FieldInfo> ValueFieldInfos { get; } = new List<FieldInfo>();
        private static List<PropertyInfo> ValuePropertyInfos { get; } = new List<PropertyInfo>();

        private static int InstantiatedCount = 0;
        private static Lazy<List<T>> LazyValues = new Lazy<List<T>>(() => InitializeValues());

        private ulong BitValue { get; set; }

        static GenericEnumBase()
        {
            var type = typeof(T);

            ValueFieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                                  .Where(f => f.FieldType == type)
                                  .ToList();

            ValuePropertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                                  .Where(p => p.PropertyType == type)
                                  .ToList();
        }
        protected GenericEnumBase(TValue value) : base(value) 
        {
            // Create dict to fix BitValue problem with two enums of same underlying value!

            var a 
            BitValue = 1UL << (Interlocked.Increment(ref InstantiatedCount) - 1);

            if (InstantiatedCount >= 64) 
            {
                throw new Exception("Can not create more than 64 values of this GenericEnum type!");
            }
        }

        public static bool operator ==(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return genericEnum0.BitValue == genericEnum1.BitValue;
        }
        public static bool operator !=(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return genericEnum0.BitValue != genericEnum1.BitValue;
        }

        public static T operator +(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromGenericEnum(genericEnum0.BitValue | genericEnum1.BitValue);
        }
        public static T operator -(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromGenericEnum(genericEnum0.BitValue & ~genericEnum1.BitValue);
        }

        public static T operator &(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromGenericEnum(genericEnum0.BitValue & genericEnum1.BitValue);
        }
        public static T operator |(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromGenericEnum(genericEnum0.BitValue | genericEnum1.BitValue);
        }
        public static T operator ^(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromGenericEnum(genericEnum0.BitValue ^ genericEnum1.BitValue);
        }

        public static IReadOnlyList<T> GetValues()
        {
            return Values;
        }

        private static Func<T> GetTypeConstructor()
        {
            // Needed, because creates type T! Not type GenericEnum<T, TValue>!

            var type = typeof(T);
            var valuePropertyType = typeof(TValue);

            var constructor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { valuePropertyType, }, null);

            if (constructor == null)
            {
                throw new Exception("No constructor found.");
            }

            var constructorExpression = Expression.Lambda<Func<T>>(Expression.New(constructor, new Expression[]
            {
                Expression.Constant(GenericDefault.GetDefault(valuePropertyType), valuePropertyType),
            }));

            var compiledConstructorExpression = constructorExpression.Compile();

            return compiledConstructorExpression;
        }
        private static List<T> InitializeValues() 
        {
            var valueFields = ValueFieldInfos.Select(f => (T)f.GetValue(null)!);
            var valueProperties = ValuePropertyInfos.Select(p => (T)p.GetValue(null)!);

            var values = new List<T>(valueFields);
            values.AddRange(valueProperties);

            return values;
        }
        private static T ConstructFromGenericEnum(ulong bitValue)
        {
            var t = TypeConstructor();
            t.BitValue = bitValue;
            t.HasValue = false;

            return t;
        }

        public bool Equals(GenericEnumBase<T, TValue>? other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return BitValue == other.BitValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is GenericEnumBase<T, TValue> geb) 
            {
                return Equals(geb);
            }

            return base.Equals(obj);
        }
        public override HashSet<GenericEnum> GetValueSet()
        {
            var hs = new HashSet<GenericEnum>();

            var c = Values.Count;
            for (var bitIndex = 0; bitIndex < c; bitIndex++) 
            {
                // If bit is set, then extract the correct value from Values.
                if ((BitValue & (1UL << bitIndex)) != 0) 
                {
                    hs.Add(Values[bitIndex]);
                }
            }

            return hs;
        }
    }
}
