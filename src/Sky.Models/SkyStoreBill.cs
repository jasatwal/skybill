using System.Collections.Generic;

namespace Sky
{
    public class SkyStoreBill : IBill
    {
        private readonly IEnumerable<SkyStorePurchase> rentals;
        private readonly IEnumerable<SkyStorePurchase> buyAndKeep;
        private readonly BillSummary summary;

        public IEnumerable<SkyStorePurchase> Rentals
        {
            get { return rentals; }
        }

        public IEnumerable<SkyStorePurchase> BuyAndKeep
        {
            get { return buyAndKeep; }
        }

        public BillSummary Summary
        {
            get { return summary; }
        }

        public SkyStoreBill(IEnumerable<SkyStorePurchase> rentals, IEnumerable<SkyStorePurchase> buyAndKeep, Money total)
        {
            Check.Argument.IsNotNull(rentals, nameof(rentals));
            Check.Argument.IsNotNull(buyAndKeep, nameof(buyAndKeep));

            this.rentals = rentals;
            this.buyAndKeep = buyAndKeep;

            summary = new BillSummary(rentals.Sum().Add(buyAndKeep.Sum()), total);
        }
    }
}
