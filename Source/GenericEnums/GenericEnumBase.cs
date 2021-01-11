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
        public static Dictionary<ulong, T> ValuesByBitValue => LazyValuesByBitValue.Value;

        private static Func<T> TypeConstructor { get; } = GetTypeConstructor();
        private static List<FieldInfo> ValueFieldInfos { get; } = new List<FieldInfo>();
        private static List<PropertyInfo> ValuePropertyInfos { get; } = new List<PropertyInfo>();

        private static object BitValueByUnderlyingValueDictionaryLock = new object();
        private static Dictionary<object, ulong> BitValueByUnderlyingValueDictionary = new Dictionary<object, ulong>();

        private static Lazy<List<T>> LazyValues = new Lazy<List<T>>(() => InitializeValues());
        private static Lazy<Dictionary<ulong, T>> LazyValuesByBitValue = new Lazy<Dictionary<ulong, T>>(() => InitializeValuesByBitValue());

        private static ulong ValueNullBitValue { get; } = 1;
        private static bool DefaultValueIsNull { get; } = GenericDefault.GetDefault(typeof(TValue)) == null;

        public ulong BitValue { get; private set; }

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
            if (value == null)
            {
                BitValue = ValueNullBitValue;
            }
            else 
            {
                if (BitValueByUnderlyingValueDictionary.TryGetValue(value, out var bitVal))
                {
                    BitValue = bitVal;
                }
                else 
                {
                    lock (BitValueByUnderlyingValueDictionaryLock) 
                    {
                        if (BitValueByUnderlyingValueDictionary.TryGetValue(value, out var bitVal2))
                        {
                            BitValue = bitVal2;
                        }
                        else 
                        {
                            if (DefaultValueIsNull)
                            {
                                // If the default of TValue is null, meaning that TValue is a class,
                                // then we reserve BitValue = 1 for the null case. Thus, the counting
                                // starts from 2, not 1.
                                BitValue = 1UL << (BitValueByUnderlyingValueDictionary.Count + 1);
                            }
                            else 
                            {
                                BitValue = 1UL << BitValueByUnderlyingValueDictionary.Count;
                            }

                            BitValueByUnderlyingValueDictionary[value] = BitValue;
                        }
                    }
                }
            }

            if (BitValueByUnderlyingValueDictionary.Count > 64 || (DefaultValueIsNull && BitValueByUnderlyingValueDictionary.Count > 63)) 
            {
                throw new Exception("Can not create more than 64 values of this GenericEnum type! Note: If TValue is a class type, then null will take reserve one value.");
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
            return ConstructFromBitValue(genericEnum0.BitValue | genericEnum1.BitValue);
        }
        public static T operator -(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromBitValue(genericEnum0.BitValue & ~genericEnum1.BitValue);
        }

        public static T operator &(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromBitValue(genericEnum0.BitValue & genericEnum1.BitValue);
        }
        public static T operator |(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromBitValue(genericEnum0.BitValue | genericEnum1.BitValue);
        }
        public static T operator ^(GenericEnumBase<T, TValue> genericEnum0, GenericEnumBase<T, TValue> genericEnum1)
        {
            return ConstructFromBitValue(genericEnum0.BitValue ^ genericEnum1.BitValue);
        }

        public static IReadOnlyList<T> GetValues()
        {
            return Values;
        }

        private static List<T> InitializeValues() 
        {
            var valueFields = ValueFieldInfos.Select(f => (T)f.GetValue(null)!);
            var valueProperties = ValuePropertyInfos.Select(p => (T)p.GetValue(null)!);

            var c = valueFields.Count() + valueProperties.Count();
            var values = new List<T>(c);
            var bitValueSet = new HashSet<ulong>(c);

            // Use BitValues rather than the value itself. Because, generating the ValueSet for 
            // GenericEnum<T, TValue> relies on the fact that the static Values property has been
            // determined, which is currently being done in this method and as such it can't exist. 

            foreach (var vf in valueFields)
            {
                if (!bitValueSet.Contains(vf.BitValue))
                {
                    values.Add(vf);
                    bitValueSet.Add(vf.BitValue);
                }
            }

            // Maybe unnecessary. Because properties (usually) have backing fields.
            foreach (var vp in valueProperties)
            {
                if (!bitValueSet.Contains(vp.BitValue))
                {
                    values.Add(vp);
                    bitValueSet.Add(vp.BitValue);
                }
            }

            return values;
        }
        private static Dictionary<ulong, T> InitializeValuesByBitValue()
        {
            var valuesByBitValue = new Dictionary<ulong, T>(Values.Count);

            foreach (var v in Values) 
            {
                valuesByBitValue[v.BitValue] = v;
            }

            return valuesByBitValue;
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
        private static T ConstructFromBitValue(ulong bitValue)
        {
            var t = TypeConstructor();
            t.HasValue = false;
            t.InternalValue = null;
            t.BitValue = bitValue;
            t.Value = (TValue)GenericDefault.GetDefault(typeof(TValue))!;

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
        internal override HashSet<GenericEnum> GetValueSet()
        {
            var hs = new HashSet<GenericEnum>();

            var c = Values.Count;

            /*
            This code assumes that Values is sorted, which is not currently the case.

            for (var bitIndex = 0; bitIndex < c; bitIndex++) 
            {
                // If bit is set, then extract the correct value from Values.
                if ((BitValue & (1UL << bitIndex)) != 0) 
                {
                    hs.Add(Values[bitIndex]);
                }
            }
            */

            for (var bitIndex = 0; bitIndex < c; bitIndex++) 
            {
                // If bit is set, then extract the correct value from Values.
                var bit = BitValue & (1UL << bitIndex);
                if (ValuesByBitValue.TryGetValue(bit, out var value))
                {
                    hs.Add(value);
                }
            }


            return hs;
        }
    }
}
