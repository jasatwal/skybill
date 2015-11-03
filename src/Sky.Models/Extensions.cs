using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    public static class Extensions
    {
        public static Money Sum(this IEnumerable<IBillItem> items)
        {
            return new Money(items.Sum(x => x.Cost.Value));
        }
        
    }
}
