using System.Collections.Generic;

namespace Sky
{
    public class CallChargesBill : IBill
    {
        public static readonly CallChargesBill None = new CallChargesBill(new CallCharge[0], Money.Zero);

        private readonly IEnumerable<CallCharge> calls;
        private readonly BillSummary summary;

        public IEnumerable<CallCharge> Calls
        {
            get { return calls; }
        }

        public BillSummary Summary
        {
            get { return summary; }
        }

        public CallChargesBill(IEnumerable<CallCharge> calls, Money total)
        {
            Check.Argument.IsNotNull(calls, nameof(calls));

            this.calls = calls;

            summary = new BillSummary(calls.Sum(), total);
        }
    }
}
