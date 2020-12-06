using Acmion.GenericEnums;

namespace GenericEnumsDemo
{
    public class FirstInt : GenericEnumBase<FirstInt, int>
    {
        /*
            FirstInt is the type of the custom GenericEnum.
            GenericEnumBase<T, TValue> is the class that should be inherited when creating custom GenericEnums.
                T is the type of the custom GenericEnum (FirstInt here).
                TValue is the type of the underlying value (int here).
        */        

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
}