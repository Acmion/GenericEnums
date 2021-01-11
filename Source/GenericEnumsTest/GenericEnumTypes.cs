using Acmion.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsTest
{
    public class PositiveNumber : GenericEnumBase<PositiveNumber, int>
    {
        // All definitions here have a defined Value property.
        // All definitions here have a defined ValueSet property.

        // All static fields and properties of type PositiveNumber declared in this class, 
        // regardless of the access modifier, will be added to PositiveNumber.Values.

        public static readonly PositiveNumber Zero = new PositiveNumber(0);
        public static readonly PositiveNumber One = new PositiveNumber(1);
        public static readonly PositiveNumber Two = new PositiveNumber(2);
        public static readonly PositiveNumber Three = new PositiveNumber(3);
        public static readonly PositiveNumber Four = new PositiveNumber(4);
        public static readonly PositiveNumber Five = new PositiveNumber(5);
        public static readonly PositiveNumber Six = new PositiveNumber(6);
        public static readonly PositiveNumber Seven = new PositiveNumber(7);
        public static readonly PositiveNumber Eight = new PositiveNumber(8);
        public static readonly PositiveNumber Nine = new PositiveNumber(9);
        public static readonly PositiveNumber Ten = new PositiveNumber(10);

        protected PositiveNumber(int number) : base(number) { }
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

        public static readonly PositiveNumber All = PositiveNumber.One | PositiveNumber.Two | PositiveNumber.Three |
                                                    PositiveNumber.Four | PositiveNumber.Five | PositiveNumber.Six |
                                                    PositiveNumber.Seven | PositiveNumber.Eight | PositiveNumber.Nine |
                                                    PositiveNumber.Ten | PositiveNumber.Zero;

        public static readonly PositiveNumber Odd = PositiveNumber.One | PositiveNumber.Three | PositiveNumber.Five | PositiveNumber.Seven | PositiveNumber.Nine;
        public static readonly PositiveNumber Even = PositiveNumber.Two | PositiveNumber.Four | PositiveNumber.Six | PositiveNumber.Eight | PositiveNumber.Ten;

        public static readonly PositiveNumber GreaterThanFive = PositiveNumber.Six | PositiveNumber.Seven | PositiveNumber.Eight | PositiveNumber.Nine | PositiveNumber.Ten;

        public static readonly PositiveNumber GreaterThanFiveAndOdd = GreaterThanFive & Odd;
        public static readonly PositiveNumber GreaterThanFiveAndEven = GreaterThanFive & Even;
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
}
