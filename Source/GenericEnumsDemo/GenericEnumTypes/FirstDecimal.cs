using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class FirstDecimal : GenericEnumBase<FirstDecimal, decimal>
    {
        public static readonly FirstDecimal Zero = new FirstDecimal(0.0m);

        public static readonly FirstDecimal One = new FirstDecimal(1.0m);
        public static readonly FirstDecimal Two = new FirstDecimal(2.0m);
        public static readonly FirstDecimal Three = new FirstDecimal(3.0m);

        public static readonly FirstDecimal PiWith20DecimalPlaces = new FirstDecimal(3.14159265358979323846m);

        protected FirstDecimal(decimal number) : base(number) 
        { }
    }

}
