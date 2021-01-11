using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class CustomType : GenericEnumBase<CustomType, string?>
    {
        public static CustomType Acmion { get; } = new CustomType("Acmion");
        public static CustomType HelloWorld { get; } = new CustomType("Hello World");
        public static CustomType HelloWorldAlt { get; } = new CustomType("Hello World");
        public static CustomType Null { get; } = new CustomType(null);

        public static CustomType AcmionAndNull = Acmion | Null;
        public static GenericEnum AcmionAndHelloWorld = Acmion | HelloWorld;

        // The static property Values (in this case CustomType.Values) is defined as follows:
        // 1. Include fields of type CustomType. Note: Properties may have generated backing fields.
        // 2. Include properties of type CustomType. 
        // 3. Include no duplicates.
        // Thus, 
        // CustomType.Values = [Acmion, HelloWorld, Null, AcmionAndNull]
        // Note: HelloWorldAlt is not included because it is a duplicate and AcmionAndHelloWorld is not included, because it's type is GenericEnum and not CustomType.

        protected CustomType(string? value) : base(value) 
        {
        }
    }
}
