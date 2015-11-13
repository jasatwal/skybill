using Sky.Billing;
using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    public static class Extensions
    {
        public static Money Sum(this IEnumerable<ICost> items)
        {
            return new Money(items.Select(x => x.Cost).Sum());
        }

        public static Money Sum(this IEnumerable<IBreakdown> items)
        {
            return items.Select(x => x.Costings.Total).Sum();
        }

        public static Money Sum(this IEnumerable<Money> items)
        {
            return new Money(items.Sum(x => x.Value));
        }
    }
}
