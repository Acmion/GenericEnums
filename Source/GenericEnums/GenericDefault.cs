using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.GenericEnums
{
    public static class GenericDefault
    {
        private static Dictionary<Type, object?> Defaults { get; } = new Dictionary<Type, object?>();
        private static object DefaultsLock = new object();

        public static object? GetDefault(Type t)
        {
            if (Defaults.TryGetValue(t, out var def)) 
            {
                return def;
            }

            lock (DefaultsLock) 
            {
                // If another thread has finished creating the value, then we just return it.
                if (Defaults.TryGetValue(t, out var defLock))
                {
                    return defLock;
                }
                else 
                {
                    var getDefaultGenericMethod = typeof(GenericDefault).GetMethod(nameof(GetDefaultGeneric), BindingFlags.Static | BindingFlags.NonPublic);
                    var defGen = getDefaultGenericMethod!.MakeGenericMethod(t).Invoke(null, null);

                    Defaults[t] = defGen;

                    return defGen;
                }
            }
        }

        private static TArg? GetDefaultGeneric<TArg>()
        {
            return default(TArg);
        }
    }
}
