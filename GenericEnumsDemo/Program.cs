using Acmion.GenericEnums;
using GenericEnumsDemo.Operators;
using System;

namespace GenericEnumsDemo
{
    public class FirstInt : GenericEnumBase<FirstInt, int>
    {
        // All definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.

        // All static fields and properties of type PositiveNumber declared in this class, 
        // regardless of the access modifier, will be added to PositiveNumber.Values.

        public static readonly FirstInt Zero = new FirstInt(0);
        public static readonly FirstInt One = new FirstInt(1);
        public static readonly FirstInt Two = new FirstInt(2);
        public static readonly FirstInt Three = new FirstInt(3);
        public static readonly FirstInt Four = new FirstInt(4);
        public static readonly FirstInt Five = new FirstInt(5);
        public static readonly FirstInt Six = new FirstInt(6);
        public static readonly FirstInt Seven = new FirstInt(7);
        public static readonly FirstInt Eight = new FirstInt(8);
        public static readonly FirstInt Nine = new FirstInt(9);
        public static readonly FirstInt Ten = new FirstInt(10);

        protected FirstInt(int number) : base(number) { }
    }

    public class SecondInt : GenericEnumBase<SecondInt, int>
    {
        public static readonly SecondInt Three = new SecondInt(3);
        public static readonly SecondInt Two = new SecondInt(2);
        public static readonly SecondInt One = new SecondInt(1);
        public static readonly SecondInt Zero = new SecondInt(0);

        protected SecondInt(int number) : base(number) { }
    }

    public class FirstLong : GenericEnumBase<FirstLong, long>
    {
        public static readonly FirstLong Zero = new FirstLong(0);
        public static readonly FirstLong One = new FirstLong(1);
        public static readonly FirstLong Two = new FirstLong(2);
        public static readonly FirstLong Three = new FirstLong(3);

        protected FirstLong(long number) : base(number) { }
    }

    public class NegativeNumber : GenericEnumBase<NegativeNumber, int>
    {
        // All definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.

        // All static fields and properties of type NegativeNumber declared in this class, 
        // regardless of the access modifier, will be added to NegativeNumber.Values.

        public static readonly NegativeNumber MinusZero = new NegativeNumber(-0);
        public static readonly NegativeNumber MinusOne = new NegativeNumber(-1);
        public static readonly NegativeNumber MinusTwo = new NegativeNumber(-2);
        public static readonly NegativeNumber MinusThree = new NegativeNumber(-3);
        public static readonly NegativeNumber MinusFour = new NegativeNumber(-4);
        public static readonly NegativeNumber MinusFive = new NegativeNumber(-5);
        public static readonly NegativeNumber MinusSix = new NegativeNumber(-6);
        public static readonly NegativeNumber MinusSeven = new NegativeNumber(-7);
        public static readonly NegativeNumber MinusEight = new NegativeNumber(-8);
        public static readonly NegativeNumber MinusNine = new NegativeNumber(-9);
        public static readonly NegativeNumber MinusTen = new NegativeNumber(-10);

        protected NegativeNumber(int number) : base(number) { }
    }

    public static class PositiveNumberSets 
    {
        // No definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.

        // No declared in this class will be added to PositiveNumber.Values.

        public static readonly FirstInt All = FirstInt.One | FirstInt.Two | FirstInt.Three | 
                                                    FirstInt.Four | FirstInt.Five | FirstInt.Six | 
                                                    FirstInt.Seven | FirstInt.Eight | FirstInt.Nine | 
                                                    FirstInt.Ten | FirstInt.Zero;

        public static readonly FirstInt Odd = FirstInt.One | FirstInt.Three | FirstInt.Five | FirstInt.Seven | FirstInt.Nine;
        public static readonly FirstInt Even = FirstInt.Two | FirstInt.Four | FirstInt.Six | FirstInt.Eight | FirstInt.Ten;

        public static readonly FirstInt GreaterThanFive = FirstInt.Six | FirstInt.Seven | FirstInt.Eight | FirstInt.Nine | FirstInt.Ten;

        public static readonly FirstInt GreaterThanFiveAndOdd = GreaterThanFive & Odd;
        public static readonly FirstInt GreaterThanFiveAndEven = GreaterThanFive & Even;
    }

    public static class NegativeNumberSets 
    {
        // No definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.

        // No declared in this class will be added to PositiveNumber.Values.

        public static readonly NegativeNumber All = NegativeNumber.MinusOne | NegativeNumber.MinusTwo | NegativeNumber.MinusThree | 
                                                    NegativeNumber.MinusFour | NegativeNumber.MinusFive | NegativeNumber.MinusSix | 
                                                    NegativeNumber.MinusSeven | NegativeNumber.MinusEight | NegativeNumber.MinusNine | 
                                                    NegativeNumber.MinusTen | NegativeNumber.MinusZero;

        public static readonly NegativeNumber Odd = NegativeNumber.MinusOne | NegativeNumber.MinusThree | NegativeNumber.MinusFive | NegativeNumber.MinusSeven | NegativeNumber.MinusNine;
        public static readonly NegativeNumber Even = NegativeNumber.MinusTwo | NegativeNumber.MinusFour | NegativeNumber.MinusSix | NegativeNumber.MinusEight | NegativeNumber.MinusTen;

        public static readonly NegativeNumber LessThanMinusFive = NegativeNumber.MinusSix | NegativeNumber.MinusSeven | NegativeNumber.MinusEight | NegativeNumber.MinusNine | NegativeNumber.MinusTen;

        public static readonly NegativeNumber LessThanMinusFiveAndOdd = LessThanMinusFive & Odd;
        public static readonly NegativeNumber LessThanMinusFiveAndEven = LessThanMinusFive & Even;
    }

    public class DecimalNumber : GenericEnumBase<DecimalNumber, double>
    {
        public static readonly DecimalNumber Zero = new DecimalNumber(0.0);
        public static readonly DecimalNumber One = new DecimalNumber(1.0);
        public static readonly DecimalNumber Two = new DecimalNumber(2.0);

        public static readonly DecimalNumber All = Zero | One | Two;

        protected DecimalNumber(double value) : base(value) { }
    }

    class Program
    {
        // Some definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.
        // Note: All types are GenericEnum, because the combining operators operate on different types.

        public static readonly GenericEnum AbsoluteOne = FirstInt.One | NegativeNumber.MinusOne;

        public static readonly GenericEnum AllNumbers = PositiveNumberSets.All | NegativeNumberSets.All;
        public static readonly GenericEnum AllOddNumbers = PositiveNumberSets.Odd | NegativeNumberSets.Odd;
        public static readonly GenericEnum AllEvenNumbers = PositiveNumberSets.Even | NegativeNumberSets.Even;

        public static readonly GenericEnum AllAbsoluteValueGreaterThanFive = PositiveNumberSets.GreaterThanFive | NegativeNumberSets.LessThanMinusFive;

        public static readonly GenericEnum GreaterThanFive = FirstInt.Six | FirstInt.Seven | FirstInt.Eight | FirstInt.Nine | FirstInt.Ten;

        // Just a strange, but possible, way to get the value of PositiveNumber.One.
        public static readonly GenericEnum ConvolutedPositiveOne = AllNumbers & FirstInt.One;

        // Just two empty sets.
        public static readonly GenericEnum EmptySet0 = PositiveNumberSets.All & NegativeNumberSets.All;
        public static readonly GenericEnum EmptySet1 = PositiveNumberSets.GreaterThanFive & NegativeNumberSets.LessThanMinusFive;

        public static void Main(string[] args)
        {
            //UnionOperator.Demo();
            //IntersectOperator.Demo();
            //SymmetricExceptOperator.Demo();

            //ExceptOperator.Demo();
            //SecondaryUnionOperator.Demo();

            //EqualityOperator.Demo();
            InequalityOperator.Demo();

            /*
                Key features of GenericEnums:
                1. All GenericEnums have a ValueSet property of type HashSet<GenericEnum>, which contains all values associated with a specific GenericEnum.
                2. All GenericEnums have an explicit InternalValue property if and only if ValueSet.Count == 1. You can check for this with the property HasValue.
                3. Most GenericEnumss have an explicitly typed Value property, if they have an explicit InternalValue, which is just casted from InternalValue.
                4. The InternalValue is always contained within ValueSet.
                5. Any combining operator (for example: &) on two GenericEnums will always return a new object, in other words a new reference.
                6. Combining operators are left associative. This means that operators on the left are executed first.
                
                The equality of two GenericEnums A and B is defined as:
                1. If both have an explicit Value of the same type, then they are considered to be equal if A.Value == B.Value.
                2. If both have an explicit InternalValue (that is not of the same type), then they are considered to be equal if A.InternalValue == B.InternalValue.
                3. Otherwise they are considered to be equal if the values in the ValueSet of both are equal. That is A.ValueSet.SetEquals(B.ValueSet).
            */

            // Basic Features

            //Console.WriteLine(FirstInt.One);
            // Returns: 1. Because the Value is 1.            
            // Type: FirstInt. Because all types are FirstInt.






            /*
            Console.WriteLine(FirstInt.One + SecondInt.Two);
            // Returns: 1, 2. Because the plus (+) operator creates a union without duplicates of the given arguments. Note: The types of both Values are different.
            // Type: GenericEnumValue<int>. Because PositiveNumber and OtherPositiveNumber are not the same type, but they share the Value type, which is int.

            Console.WriteLine(FirstInt.One + SecondInt.Two);
            // Returns: 1, 2. Because the plus (+) operator creates a union without duplicates of the given arguments. Note: The types of both Values are different.
            // Type: GenericEnumValue<int>. Because PositiveNumber and OtherPositiveNumber are not the same type, but they share the Value type, which is int.

            Console.WriteLine(FirstInt.One + NegativeNumber.MinusOne);
            // Returns: 1, -1. Because the plus (+) operator creates a union without duplicates of the given arguments.
            // Type: GenericEnumValue<int>. Because PositiveNumber and NegativeNumber are not the same type, but they share the Value type, which is int.


            Console.WriteLine(FirstInt.One + FirstInt.One + NegativeNumber.MinusOne);
            // Returns: 1, -1. Because the plus (+) operator creates a union without duplicates of the given arguments.
            // Type: GenericEnumValue<int>. Because PositiveNumber and NegativeNumber are not the same type, but they share the Value type, which is int.

            Console.WriteLine(FirstInt.One + FirstInt.One + NegativeNumber.MinusOne - NegativeNumber.MinusOne);
            // Returns: 1. Because the minus (-) operator subtracts the second argument from the first argument.
            // Type: GenericEnumValue<int>. Because PositiveNumber and NegativeNumber are not the same type, but they share the Value type, which is int.

            Console.WriteLine(FirstInt.One - FirstInt.One);
            // Returns: <EMPTY SET>. Because the minus (-) operator subtracts the second argument from the first argument, however, no minus values are kept. 
            // Type: PositiveNumber. Because both types are PositiveNumber.

            Console.WriteLine(FirstInt.One | FirstInt.One | NegativeNumber.MinusOne);
            // Returns: 1. Because the or (|) operator creates a union without duplicates of the given arguments.
            // Type: GenericEnumValue<int>. Because PositiveNumber and NegativeNumber are not the same type, but they share the Value type, which is int. 

            Console.WriteLine((FirstInt.One + FirstInt.Two) & (FirstInt.Two + FirstInt.Three));
            // Returns: 2. Because the and (&) operator calculates the intersection of two sets.
            // Type: PositiveNumber. Because all types are PositiveNumber.

            Console.WriteLine((FirstInt.One + FirstInt.Two) & (FirstInt.Three + FirstInt.Four));
            // Returns: <EMPTY SET>. Because the and (&) operator calculates the intersection of two sets.
            // Type: PositiveNumber. Because all types are PositiveNumber.

            Console.WriteLine((FirstInt.One + FirstInt.Two) ^ (FirstInt.Two + FirstInt.Three));
            // Returns: 1, 3. Because the xor (^) operator calculates the xor of the sets.
            // Type: PositiveNumber. Because all types are PositiveNumber.


            // Equality

            Console.WriteLine(FirstInt.Zero == FirstInt.Zero);
            // True, because the Value properties have the same value.

            Console.WriteLine(FirstInt.Zero == FirstInt.One);
            // False, because the Value properties do not have the same value.

            Console.WriteLine(ConvolutedPositiveOne == FirstInt.One);
            // True, because the values in ValueSet of both PositiveNumber.One and NegativeNumber.MinusOne are the same. Note, these items do not share the same reference.

            Console.WriteLine(FirstInt.One == NegativeNumber.MinusOne);
            // False, because the values in ValueSet of both PositiveNumber.One and NegativeNumber.MinusOne are not the same. Note, these items do not share the same reference.

            Console.WriteLine(GreaterThanFive == PositiveNumberSets.GreaterThanFive);
            // True, because the values in ValueSet of both GreaterThanFive and PositiveNumberSets.GreaterThanFive are the same. Note, these items do not share the same reference.

            Console.WriteLine(FirstInt.Zero == NegativeNumber.MinusZero);
            // True, because the Value of both PositiveNumber and NegativeNumber is 0 and of type int.

            Console.WriteLine(FirstInt.Zero == DecimalNumber.Zero);
            // False, because the Value of both PositiveNumber and DecimalNumber is 0, but they are of different types (double and int). Note, usually in C# 0 == 0.0 is true, but not here.

            Console.WriteLine(NegativeNumber.MinusZero == DecimalNumber.Zero);
            // False, because the Value of both NegativeNumber and DecimalNumber is 0, but they are of different types (double and int). Note, usually in C# 0 == 0.0 is true, but not here.

            Console.WriteLine(AllEvenNumbers.HasFlag(FirstInt.One));
            // False, because AllEvenNumbers is not a superset of PositiveNumber.One. 

            Console.WriteLine(AllEvenNumbers.HasFlag(FirstInt.Two));
            // True, because AllEvenNumbers is a superset of PositiveNumber.Two. 

            Console.WriteLine(AllEvenNumbers.HasFlag(PositiveNumberSets.Even));
            // True, because AllEvenNumbers is a superset of PositiveNumberSets.Even. 

            Console.WriteLine(FirstInt.One == AllNumbers);
            // False, because PositiveNumber.One is not a superset AllNumbers.

            Console.WriteLine(AbsoluteOne == (FirstInt.One | NegativeNumber.MinusOne));
            // True, because the ValueSet of both are equal.

            Console.WriteLine(EmptySet0 == EmptySet1);
            // True, because the ValueSet of both are equal.

            Console.WriteLine(FirstInt.One == EmptySet1);
            // False, because the ValueSet of both are not equal.

            var a = FirstInt.GetValues();
            var b = NegativeNumber.GetValues();
            var c = DecimalNumber.GetValues();
            var d = GenericEnum.GetValues(typeof(DecimalNumber));

            */
        }
    }
}
