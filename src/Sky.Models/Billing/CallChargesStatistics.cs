using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Billing
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

    public static class CallChargesStaticticsExtensions
    {
        public static IEnumerable<CalledFrequency> GetCalledFrequency(this CallChargesBill bill)
        {
            return new CallChargesStatistics(bill).GetCalledFrequency();
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
            this.number = number;
            this.frequency = frequency;
        }
    }
}
