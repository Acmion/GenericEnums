using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.GenericEnums
{
    public class GenericEnum : IGenericEnum, IEquatable<GenericEnum>
    {
        public bool HasValue { get; internal set; }
        public dynamic? InternalValue { get; internal set; }
        public virtual HashSet<GenericEnum> ValueSet => _lazyValueSet.Value;

        private HashSet<GenericEnum>? _valueSet;

        private Lazy<int> _cachedHashCode;
        private Lazy<HashSet<GenericEnum>> _lazyValueSet;

        protected GenericEnum(dynamic? internalValue)
        {
            HasValue = true;
            InternalValue = internalValue;

            _cachedHashCode = new Lazy<int>(() => CalculateCachedHashCode());
            _lazyValueSet = new Lazy<HashSet<GenericEnum>>(() => GetValueSet());
        }
        internal GenericEnum(HashSet<GenericEnum> enumSet)
        {
            HasValue = false;
            InternalValue = null;

            _valueSet = enumSet;

            _cachedHashCode = new Lazy<int>(() => CalculateCachedHashCode());
            _lazyValueSet = new Lazy<HashSet<GenericEnum>>(() => GetValueSet());
        }

        public static bool operator ==(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            try
            {
                if (genericEnum0.HasValue && genericEnum1.HasValue)
                {
                    return genericEnum0.InternalValue == genericEnum1.InternalValue;
                }
                else if (genericEnum0.ValueSet.Count == 1 && genericEnum1.ValueSet.Count == 1)
                {
                    return genericEnum0.ValueSet.First() == genericEnum1.ValueSet.First();
                }
            }
            catch 
            {
                return false;
            }

            return genericEnum0.ValueSet.SetEquals(genericEnum1.ValueSet);
        }
        public static bool operator !=(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            return !(genericEnum0 == genericEnum1);
        }

        public static GenericEnum operator +(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.UnionWith(genericEnum1.ValueSet);

            return new GenericEnum(enumSet);
            
        }
        public static GenericEnum operator -(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.ExceptWith(genericEnum1.ValueSet);

            return new GenericEnum(enumSet);
        }

        public static GenericEnum operator &(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.IntersectWith(genericEnum1.ValueSet);

            return new GenericEnum(enumSet);
            
        }
        public static GenericEnum operator |(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            return genericEnum0 + genericEnum1;
        }
        public static GenericEnum operator ^(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.SymmetricExceptWith(genericEnum1.ValueSet);

            return new GenericEnum(enumSet);
        }

        public static IReadOnlyList<GenericEnum> GetValues(Type genericEnumType) 
        {
            if (genericEnumType.IsSubclassOf(typeof(GenericEnum))) 
            {
                var values = genericEnumType.BaseType?.GetMethod("GetValues", BindingFlags.Static | BindingFlags.Public)?.Invoke(null, null) as IEnumerable;

                if (values == null)
                {
                    throw new Exception("The method GetValues is not implemented or of the wrong type.");
                }
                else 
                {
                    return values.Cast<GenericEnum>().ToList();
                }
            }

            throw new Exception("Type does not inherit GenericEnum.");
        }

        public bool HasFlag(GenericEnum other)
        {
            return ValueSet.IsSupersetOf(other.ValueSet);
        }
        public virtual bool Equals(GenericEnum? other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return this == other;
        }

        internal virtual HashSet<GenericEnum> GetValueSet()
        {
            if (HasValue)
            {
                var hs = new HashSet<GenericEnum>();
                hs.Add(this);

                return hs;
            }
            else if (_valueSet != null)
            {
                return _valueSet;
            }

            return new HashSet<GenericEnum>();
        }

        private int CalculateCachedHashCode() 
        {
            if (HasValue)
            {
                // If type of InternalValue is "numeric", then cast to Double
                // and apply that hashcode. Else just get the hashcode of InternalValue.
                // If InternalValue is null, then don't do any changes.

                if (InternalValue != null)
                {
                    switch (Type.GetTypeCode(InternalValue.GetType()))
                    {
                        // No TypeCode.Decimal here.
                        // You can not in C# execute: double == decimal

                        case TypeCode.Byte:
                        case TypeCode.SByte:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Double:
                        case TypeCode.Single:
                            return Convert.ToDouble(InternalValue).GetHashCode();
                        default:
                            return InternalValue.GetHashCode();
                    }
                }

                return 0;
            }

            var hash = 0;
            
            foreach (var ge in ValueSet) 
            {
                hash ^= ge.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            if (HasValue)
            {
                return InternalValue?.ToString() ?? "";
            }
            else if (ValueSet.Count == 0) 
            {
                return "<EMPTY SET>";
            }

            return string.Join(", ", ValueSet);
        }
        public override int GetHashCode()
        {
            return _cachedHashCode.Value;
        }
        public override bool Equals(object? obj)
        {
            if (obj is GenericEnum ge)
            {
                return Equals(ge);
            }

            return false;
        }
    }
}
