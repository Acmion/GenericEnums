using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class FirstLong : GenericEnumBase<FirstLong, long>
    {
        public static readonly FirstLong Zero = new FirstLong(0);
        public static readonly FirstLong ZeroZero = new FirstLong(00);

        public static readonly FirstLong One = new FirstLong(1);
        public static readonly FirstLong Two = new FirstLong(2);
        public static readonly FirstLong Three = new FirstLong(3);

        protected FirstLong(long number) : base(number) 
        { }
    }
}
