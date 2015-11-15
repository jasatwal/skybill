using System.Collections.Generic;

namespace Sky.Billing.Statistics
{
    public class SkyStoreStatistics
    {
        private readonly SkyStoreBill bill;

        public SkyStoreStatistics(SkyStoreBill bill)
        {
            Check.Argument.IsNotNull(bill, nameof(bill));

            this.bill = bill;
        }

        public IEnumerable<SkyStoreChargeValue> GetChargesValue()
        {
            yield return new SkyStoreChargeValue("Rentals", bill.Rentals.Sum());
            yield return new SkyStoreChargeValue("Buy and keep", bill.BuyAndKeep.Sum());
        }
    }

    public class SkyStoreChargeValue
    {
        private readonly string name;
        private readonly Money value;

        public string Name
        {
            get { return name; }
        }

        public Money Value
        {
            get { return value; }
        }

        public SkyStoreChargeValue(string name, Money value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
