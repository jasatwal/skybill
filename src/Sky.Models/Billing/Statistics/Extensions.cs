using System.Collections.Generic;

namespace Sky.Billing.Statistics
{
    public static class Extensions
    {
        public static IEnumerable<CalledFrequency> GetCalledFrequency(this CallChargesBill bill)
        {
            return new CallChargesStatistics(bill).GetCalledFrequency();
        }

        public static IEnumerable<SkyStoreChargeValue> GetSkyStoreChargesValue(this SkyStoreBill bill)
        {
            return new SkyStoreStatistics(bill).GetChargesValue();
        }
    }
}
