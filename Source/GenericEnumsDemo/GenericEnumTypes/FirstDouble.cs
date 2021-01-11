using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class FirstDouble : GenericEnumBase<FirstDouble, double>
    {
        public static FirstDouble Zero { get; } = new FirstDouble(0.0);

        public static readonly FirstDouble One = new FirstDouble(1.0);
        public static readonly FirstDouble Two = new FirstDouble(2.0);
        public static readonly FirstDouble Three = new FirstDouble(3.0);

        public static readonly FirstDouble PiWith20DecimalPlaces = new FirstDouble(3.14159265358979323846);

        // The static property Values (in this case FirstDouble.Values) is defined as follows:
        // 1. Include fields of type FirstDouble. Note: Properties may have generated backing fields.
        // 2. Include properties of type FirstDouble. 
        // 3. Include no duplicates.
        // Thus, 
        // FirstDouble.Values = [Zero, One, Two, Three, PiWith20DecimalPlaces]
        // Note: Zero comes first because it is a property with a backing field.

        protected FirstDouble(double number) : base(number) 
        { }
    }

}
