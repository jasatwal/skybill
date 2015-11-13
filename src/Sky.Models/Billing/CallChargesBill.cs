using System.Collections.Generic;

namespace Sky.Billing
{
    public class CallChargesBill : IBill
    {
        private readonly IEnumerable<CallCharge> calls;
        private readonly BillCostings costings;

        public IEnumerable<CallCharge> Calls
        {
            get { return calls; }
        }

        public BillCostings Costings
        {
            get { return costings; }
        }

        public CallChargesBill(IEnumerable<CallCharge> calls, Money total)
        {
            Check.Argument.IsNotNull(calls, nameof(calls));
            Check.Argument.IsNotNull(total, nameof(total));

            this.calls = calls;

            costings = new BillCostings(calls.Sum(), total);
        }

        //public ChargeBreakdown Breakdown()
        //{
        //    return new ChargeBreakdown(
        //        "Call Charges",
        //        total,
        //        new ChargeBreakdownCategory("Calls", calls));
        //}
    }
}
