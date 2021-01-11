using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnumsBenchmark.Utils
{
    public static class Extensions
    {
        private static Random TakeRandomRandom = new Random();

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> enumerable, int count) 
        {
            return enumerable.OrderBy(t => TakeRandomRandom.NextDouble()).Take(count);
        }
    }
}
