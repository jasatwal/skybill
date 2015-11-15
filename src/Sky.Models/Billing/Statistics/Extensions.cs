using System.Collections.Generic;
using System.Linq;

namespace Sky.Billing.Statistics
{
    public static class Extensions
    {
        public static IEnumerable<CalledFrequency> GetCalledFrequency(this Bill bill)
        {
            if (bill.CallCharges == null)
                return Enumerable.Empty<CalledFrequency>();

            return new CallChargesStatistics(bill.CallCharges).GetCalledFrequency();
        }

        public static IEnumerable<SkyStoreChargeValue> GetSkyStoreChargesValue(this Bill bill)
        {
            if (bill.SkyStore == null)
                return Enumerable.Empty<SkyStoreChargeValue>();

            return new SkyStoreStatistics(bill.SkyStore).GetChargesValue();
        }
    }
}
