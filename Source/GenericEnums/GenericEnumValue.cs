using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.GenericEnums
{
    public class GenericEnumValue<TValue> : GenericEnum, IGenericEnumValue<TValue>, IEquatable<GenericEnumValue<TValue>>
    {
        public TValue? Value { get; internal set; }

        protected GenericEnumValue(TValue value) : base(value)
        {
            Value = value;
        }
        internal GenericEnumValue(HashSet<GenericEnum> enumSet) : base(enumSet) 
        {
            Value = (TValue)GenericDefault.GetDefault(typeof(TValue))!;
        }

        public static bool operator ==(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            try
            {
                if (genericEnum0.HasValue && genericEnum1.HasValue)
                {
                    return genericEnum0.Value!.Equals(genericEnum1.Value!);
                }
                else if (genericEnum0.ValueSet.Count == 1 && genericEnum1.ValueSet.Count == 1)
                {
                    var ge0 = genericEnum0.ValueSet.First();
                    var ge1 = genericEnum1.ValueSet.First();

                    if (ge0 is GenericEnumValue<TValue> gev0 && gev0.HasValue)
                    {
                        if (ge1 is GenericEnumValue<TValue> gev1 && gev1.HasValue)
                        {
                            return gev0.Value!.Equals(gev1.Value!);
                        }
                    }

                    return ge0 == ge1;
                }
            }
            catch 
            {
                return false;
            }

            return genericEnum0.ValueSet.SetEquals(genericEnum1.ValueSet);
        }
        public static bool operator !=(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            return !(genericEnum0 == genericEnum1);
        }

        public static GenericEnumValue<TValue> operator +(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.UnionWith(genericEnum1.ValueSet);

            return new GenericEnumValue<TValue>(enumSet);

        }
        public static GenericEnumValue<TValue> operator -(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.ExceptWith(genericEnum1.ValueSet);

            return new GenericEnumValue<TValue>(enumSet);
        }

        public static GenericEnumValue<TValue> operator &(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.IntersectWith(genericEnum1.ValueSet);

            return new GenericEnumValue<TValue>(enumSet);

        }
        public static GenericEnumValue<TValue> operator |(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            return genericEnum0 + genericEnum1;
        }
        public static GenericEnumValue<TValue> operator ^(GenericEnumValue<TValue> genericEnum0, GenericEnumValue<TValue> genericEnum1)
        {
            var enumSet = new HashSet<GenericEnum>(genericEnum0.ValueSet);
            enumSet.SymmetricExceptWith(genericEnum1.ValueSet);

            return new GenericEnumValue<TValue>(enumSet);
        }

        public bool Equals(GenericEnumValue<TValue>? other)
        {
            if (other is GenericEnumValue<TValue> gev) 
            {
                return this == gev;
            }

            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is GenericEnumValue<TValue> gev)
            {
                // See Equals(GenericEnumValue<TValue>? other)
                return this == gev;
            }

            return base.Equals(obj);
        }
        public override bool Equals(GenericEnum? other)
        {
            if (other is GenericEnumValue<TValue> gev)
            {
                // See Equals(GenericEnumValue<TValue>? other)
                return this == gev;
            }

            return base.Equals(other);
        }
    }
}
