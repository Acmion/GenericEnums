using Acmion.GenericEnums;
using GenericEnumsDemo.GenericEnumTypes;
using GenericEnumsDemo.Operators;
using GenericEnumsDemo.Other;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace GenericEnumsDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var firstIntValues = FirstInt.Values;
            var firstDoubleValues = FirstDouble.Values;

            var ce = CustomType.AcmionAndHelloWorld;
            var customTypeValues = CustomType.Values;

            //UnionOperator.Demo();
            //IntersectOperator.Demo();
            //SymmetricExceptOperator.Demo();

            //ExceptOperator.Demo();
            //SecondaryUnionOperator.Demo();

            //EqualityOperator.Demo();
            //InequalityOperator.Demo();

            HashCodeDemo.Demo();
        }
    }
}
