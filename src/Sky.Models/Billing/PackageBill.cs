using Sky.Billing;
using System.Collections.Generic;

namespace Sky
{
    public class PackageBill : IBill
    {
        private readonly IEnumerable<Subscription> subscriptions;
        private readonly BillCostings costings;

        public IEnumerable<Subscription> Subscriptions
        {
            get { return subscriptions; }
        }

        public BillCostings Costings
        {
            get { return costings; }
        }

        public PackageBill(IEnumerable<Subscription> subscriptions, Money total)
        {
            Check.Argument.ArrayLenghtIsNotZero(subscriptions, nameof(subscriptions));
            Check.Argument.IsNotNull(total, nameof(total));

            this.subscriptions = subscriptions;

            costings = new BillCostings(subscriptions.Sum(), total);
        }

        //public ChargeBreakdown Breakdown()
        //{
        //    //return new PackageBreakdown(subscriptions, total);
        //    return new ChargeBreakdown(
        //        "Package",
        //        total,
        //        new ChargeBreakdownCategory("Subscriptions", subscriptions));
        //}
    }
}