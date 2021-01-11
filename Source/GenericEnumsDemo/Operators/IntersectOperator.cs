using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acmion.GenericEnums;
using GenericEnumsDemo.GenericEnumTypes;

namespace GenericEnumsDemo.Operators
{
    public static class IntersectOperator
    {
        public static void Demo() 
        {
            // The Intersect Operator (&)
            // This operator calculates the intersection between two GenericEnums.

            var firstIntSet = FirstInt.One + FirstInt.Two + FirstInt.Three;
            var secondIntSet = SecondInt.One + SecondInt.Two + SecondInt.Three;
            var firstLongSet = FirstLong.One + FirstLong.Two + FirstLong.Three;

            // SSS
            Console.WriteLine(firstIntSet & firstIntSet);
            // Returns: 1, 2, 3. 
            // Type: FirstInt. Because all types are FirstInt.

            // SSD
            Console.WriteLine(firstIntSet & FirstInt.Three);
            // Returns: 3.
            // Type: FirstInt. Because all types are FirstInt.

            // SDS
            Console.WriteLine(firstIntSet & secondIntSet);
            // Returns: 1, 2, 3.
            // Type: GenericEnumValue<int>. Because FirstInt and SecondInt are not the same type, but they share the Value type, which is int.

            // SDD
            Console.WriteLine(firstIntSet & SecondInt.Two);
            // Returns: 2. 
            // Type: GenericEnumValue<int>. Because FirstInt and SecondInt are not the same type, but they share the Value type, which is int.

            // DDS
            Console.WriteLine(firstIntSet & firstLongSet);
            // Returns: 1, 2, 3.
            // Type: GenericEnum. Because FirstInt and FirstLong are not the same type and they do not share the Value type.

            // DDD
            Console.WriteLine(firstIntSet & FirstLong.Three);
            // Returns: 3. 
            // Type: GenericEnum. Because FirstInt and FirstLong are not the same type and they do not share the Value type.

            // Multiple Operators
            Console.WriteLine(firstIntSet & FirstInt.One & FirstLong.Two);
            // Returns: <EMPTY SET>. 
            // Type: GenericEnum. Because the types and Value types do not match.
        }
    }
}
