using System.Collections.Generic;
using System.Linq;

namespace Sky.Billing.Statistics
{
    public class CallChargesStatistics
    {
        private readonly CallChargesBill bill;

        public CallChargesStatistics(CallChargesBill bill)
        {
            Check.Argument.IsNotNull(bill, nameof(bill));

            this.bill = bill;
        }

        public IEnumerable<CalledFrequency> GetCalledFrequency()
        {
            return bill.Calls.GroupBy(x => x.Called).Select(x => new CalledFrequency(x.Key, x.Count()));
        }
    }

    public class CalledFrequency
    {
        private readonly int frequency;
        private readonly TelephoneNumber number;

        public int Frequency
        {
            get { return frequency; }
        }

        public TelephoneNumber Number
        {
            get { return number; }
        }

        public CalledFrequency(TelephoneNumber number, int frequency)
        {
            Check.Argument.IsNotNull(number, nameof(number));

            this.number = number;
            this.frequency = frequency;
        }
    }
}
