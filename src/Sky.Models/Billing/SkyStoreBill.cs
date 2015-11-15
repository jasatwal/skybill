using System.Collections.Generic;

namespace Sky.Billing
{
    public class SkyStoreBill : IBill
    {
        private readonly IEnumerable<SkyStorePurchase> rentals;
        private readonly IEnumerable<SkyStorePurchase> buyAndKeep;
        private readonly BillCostings costings;

        public IEnumerable<SkyStorePurchase> Rentals
        {
            get { return rentals; }
        }

        public IEnumerable<SkyStorePurchase> BuyAndKeep
        {
            get { return buyAndKeep; }
        }

        public BillCostings Costings
        {
            get { return costings; }
        }

        public SkyStoreBill(IEnumerable<SkyStorePurchase> rentals, IEnumerable<SkyStorePurchase> buyAndKeep, Money total)
        {
            Check.Argument.IsNotNull(rentals, nameof(rentals));
            Check.Argument.IsNotNull(buyAndKeep, nameof(buyAndKeep));

            this.rentals = rentals;
            this.buyAndKeep = buyAndKeep;

            costings = new BillCostings(rentals.Sum().Add(buyAndKeep.Sum()), total);
        }
    }
}
