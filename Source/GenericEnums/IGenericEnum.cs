using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.GenericEnums
{
    public interface IGenericEnum
    {
        bool HasValue { get; }
        object? InternalValue { get; }
        
        HashSet<GenericEnum> ValueSet { get; }
    }
}
