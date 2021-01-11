using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class FirstInt : GenericEnumBase<FirstInt, int>
    {
        public static readonly FirstInt Zero = new FirstInt(0);
        public static readonly FirstInt ZeroZero = new FirstInt(0);

        public static readonly FirstInt One = new FirstInt(1);
        public static readonly FirstInt Two = new FirstInt(2);
        public static readonly FirstInt Three = new FirstInt(3);

        // The static property Values (in this case FirstInt.Values) is defined as follows:
        // 1. Include fields of type FirstInt in the order they appear. Note: Properties may have generated backing fields.
        // 2. Include properties of type FirstInt. 
        // 3. Include no duplicates.
        // Thus, 
        // FirstInt.Values = [Zero, One, Two, Three]
        // Note: ZeroZero is not included, because it is the same as Zero (same value).

        protected FirstInt(int number) : base(number) 
        { }
    }

}
