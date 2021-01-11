using GenericEnumsDemo.GenericEnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsDemo.Other
{
    public static class HashCodeDemo
    {
        public static void Demo()
        {
            // HashCode Calculation
            // Demonstration of how HashCodes are calculated.
            // Basically, HashCodes are calculated on the basis of the Value property, however, most numeric types are casted to double.
            // The cast to double is made so that same numeric values of different types match.
            // Note: This does not apply for decimal. The reason is that the == opertor is not defined for, for example, decimal == double.
            // The HashCodes are also cached for performance reasons.
            // If a GenericEnum has more than one value in it's ValueSet, then the HashCode is the XOR result of all GenericEnums in the ValueSet.

            // Compare the HashCodes of (int) 1 and (double) 1.0.
            Console.WriteLine(1.GetHashCode() == 1.0.GetHashCode());
            // Returns: False.

            // Compare the HashCodes of FirstInt.One (Value = (int)1) and FirstDouble.One (Value = (double)1.0).
            Console.WriteLine(FirstInt.One.GetHashCode() == FirstDouble.One.GetHashCode());
            // Returns: True. Because numeric (except decimal) Values are always casted to double.

            // Compare the HashCodes of FirstInt.One and (double) 1.0.
            Console.WriteLine(FirstInt.One.GetHashCode() == 1.0.GetHashCode());
            // Returns: True. Because numeric (except decimal) Values are always casted to double.

            // Compare the HashCodes of FirstDouble.One and (double) 1.0.
            Console.WriteLine(FirstDouble.One.GetHashCode() == 1.0.GetHashCode());
            // Returns: True.

            // Showcases the logic behind a sets HashCode.
            Console.WriteLine((FirstInt.One | FirstInt.Two).GetHashCode() == (1.0.GetHashCode() ^ 2.0.GetHashCode()));
            // Returns True. Because this is how the HashCode is internally calculated.
        }
    }
}
