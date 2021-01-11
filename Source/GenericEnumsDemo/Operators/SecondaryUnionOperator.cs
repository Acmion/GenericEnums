using System;
using Acmion.GenericEnums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericEnumsDemo.GenericEnumTypes;

namespace GenericEnumsDemo.Operators
{
    public static class SecondaryUnionOperator
    {
        public static void Demo() 
        {
            // The Secondary Union Operator (+)
            // This operator calculates the union, without duplicates, of the given arguments.
            // This operator will give the same results as the union operator (|).

            // SSS
            Console.WriteLine(FirstInt.One + FirstInt.One);
            // Returns: 1.
            // Type: FirstInt. Because all types are FirstInt.

            // SSD
            Console.WriteLine(FirstInt.One + FirstInt.Two);
            // Returns: 1, 2.
            // Type: FirstInt. Because all types are FirstInt.

            // SDS
            Console.WriteLine(FirstInt.One + SecondInt.One);
            // Returns: 1.
            // Type: GenericEnumValue<int>. Because FirstInt and SecondInt are not the same type, but they share the Value type, which is int.

            // SDD
            Console.WriteLine(FirstInt.One + SecondInt.Two);
            // Returns: 1, 2. The types of the return entries are FirstInt and SecondInt, respectively. 
            // Type: GenericEnumValue<int>. Because FirstInt and SecondInt are not the same type, but they share the Value type, which is int.

            // DDS
            Console.WriteLine(FirstInt.One + FirstLong.One);
            // Returns: 1.
            // Type: GenericEnum. Because FirstInt and FirstLong are not the same type and they do not share the Value type.

            // DDD
            Console.WriteLine(FirstInt.One + FirstLong.Two);
            // Returns: 1, 2. The types of the return entries are FirstInt and FirstLong, respectively. 
            // Type: GenericEnum. Because FirstInt and FirstLong are not the same type and they do not share the Value type.

            // Multiple Operators
            Console.WriteLine(FirstInt.One + SecondInt.Two + FirstLong.Three);
            // Returns: 1, 2, 3. The types of the return entries are FirstInt, SecondInt and FirstLong, respectively.
            // Type: GenericEnum. Because the types and Value types do not match.

        }
    }
}
