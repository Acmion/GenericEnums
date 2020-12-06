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
            InternalValue = enumSet;

            _cachedHashCode = new Lazy<int>(() => CalculateCachedHashCode());
            _lazyValueSet = new Lazy<HashSet<GenericEnum>>(() => GetValueSet());
        }

        public static bool operator ==(GenericEnum genericEnum0, GenericEnum genericEnum1)
        {
            if (genericEnum0.HasValue && genericEnum1.HasValue)
            {
                return genericEnum0.InternalValue == genericEnum1.InternalValue;
            }
            else if (genericEnum0.ValueSet.Count == 1 && genericEnum1.ValueSet.Count == 1)
            {
                return genericEnum0.ValueSet.First() == genericEnum1.ValueSet.First();
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
        public virtual HashSet<GenericEnum> GetValueSet() 
        {
            if (HasValue)
            {
                var hs = new HashSet<GenericEnum>();
                hs.Add(this);

                return hs;
            }
            else if (InternalValue is HashSet<GenericEnum> hs)
            {
                return hs;
            }

            return new HashSet<GenericEnum>();
        }

        private int CalculateCachedHashCode() 
        {
            if (HasValue)
            {
                return InternalValue?.GetHashCode() ?? 0;
            }

            var hash = 0;
            
            foreach (var ge in ValueSet) 
            {
                if (ge.HasValue) 
                {
                    hash += ge.InternalValue?.GetHashCode() ?? 0;
                }
            }

            return hash;
        }

        public override string ToString()
        {
            if (HasValue) 
            {
                return InternalValue?.ToString() ?? "";
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
