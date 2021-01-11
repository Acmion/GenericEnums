using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.GenericEnumTypes
{
    public class SecondInt : GenericEnumBase<SecondInt, int>
    {
        public static readonly SecondInt Zero = new SecondInt(0);
        public static readonly SecondInt ZeroZero = new SecondInt(00);

        public static readonly SecondInt One = new SecondInt(1);
        public static readonly SecondInt Two = new SecondInt(2);
        public static readonly SecondInt Three = new SecondInt(3);

        protected SecondInt(int number) : base(number) 
        { }
    }
}
