using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var hs0 = new HashSet<A>() { new B(0), new A(""), new B(1) };
            var hs1 = new HashSet<A>() { new B(0), new A(""), new B(2) };

            Console.WriteLine(hs0.SetEquals(hs1));
        }

    }

    public class A
    {
        public object Value { get; }

        public A(object val) 
        {
            Value = val;
        }

        public override bool Equals(object obj)
        {
            if (obj is A a)
                return Value == a.Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public class B : A 
    {
        public B(int val) : base(val) { }

        public override bool Equals(object obj)
        {
            if (obj is A a)
                return a.Equals(this);
            if (obj is B b)
                return (int)Value == (int)b.Value;
            return false;
        }

        public override int GetHashCode()
        {
            return ((int)Value).GetHashCode();
        }
    }

}
