using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.Operators
{
    public static class InequalityOperator
    {
        public static void Demo() 
        {
            // The Inequality Operator (!=)
            // This operator compares whether two GenericEnums are not equal. The equality is based on the equality of the Value or ValueSet properties.

            var firstIntSet = FirstInt.One + FirstInt.Two + FirstInt.Three;
            var secondIntSet = SecondInt.One + SecondInt.Two + SecondInt.Three;
            var firstLongSet = FirstLong.One + FirstLong.Two + FirstLong.Three;

            // Just a convoluted way to describe FirstInt.One. Note that this GenericEnum does not have a value (HasValue = false).
            var convolutedFirstIntOne = (FirstInt.One + FirstInt.Two) & FirstInt.One;

            // Just a convoluted way to describe an equivalent to firstIntSet.
            var convolutedFirstIntSet = FirstInt.Zero + FirstInt.One + SecondInt.Two + FirstLong.Three - FirstLong.Zero;

            // SSS
            Console.WriteLine(FirstInt.One != FirstInt.One);
            // Returns: False. Because the Value of both are the same (the reference is also the same in this case). 

            // SSD
            Console.WriteLine(FirstInt.One != FirstInt.Two);
            // Returns: True. Because the Value of both are not the same.

            // SDS
            Console.WriteLine(FirstInt.One != SecondInt.One);
            // Returns: False. Because the Value of both are the same, even if the GenericEnums are of a different type.

            // SDD
            Console.WriteLine(FirstInt.One != SecondInt.Two);
            // Returns: True. Because the Value of both are not the same. 

            // DDS
            Console.WriteLine(FirstInt.One != FirstLong.One);
            // Returns: False. Because the Value of both are the same, even if the GenericEnums are of a different type.

            // DDD
            Console.WriteLine(FirstInt.One != FirstLong.Two);
            // Returns: True. Because the Value of both are not the same. 

            // Extra
            Console.WriteLine(FirstInt.One != convolutedFirstIntOne);
            // Returns: False. Because the ValueSet of both are equal.


            // SSS
            Console.WriteLine(firstIntSet != firstIntSet);
            // Returns: False. Because the ValueSet of both are the same (the reference is also the same in this case). 

            // SSD
            Console.WriteLine(firstIntSet != FirstInt.Two);
            // Returns: True. Because the ValueSet of both are not the same.

            // SDS
            Console.WriteLine(firstIntSet != secondIntSet);
            // Returns: False. Because the ValueSet of both are the same, even if the GenericEnums are of a different type.

            // SDD
            Console.WriteLine(firstIntSet != SecondInt.Two);
            // Returns: True. Because the ValueSet of both are not the same. 

            // DDS
            Console.WriteLine(firstIntSet != firstLongSet);
            // Returns: False. Because the ValueSet of both are the same, even if the GenericEnums are of a different type.

            // DDD
            Console.WriteLine(firstIntSet != FirstLong.Two);
            // Returns: True. Because the ValueSet of both are not the same. 

            // Extra
            Console.WriteLine(firstIntSet != convolutedFirstIntSet);
            // Returns: False. Because the ValueSet of both are equal.

        }
    }
}
