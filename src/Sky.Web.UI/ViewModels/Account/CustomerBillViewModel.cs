using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky.Web.UI.ViewModels.Account
{
    public class CustomerBillViewModel
    {
        public TvSubscriptionViewModel Tv { get; set; }
        public TalkSubscriptionViewModel Talk { get; set; }
        public BroadbandSubscriptionViewModel Broadband { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Adjustment { get; set; }
        public decimal Total { get; set; }

        public CustomerBillViewModel(CustomerBill bill)
        {
            // TODO: This mapping logic should be moved to somewhere else.

            if (bill.Package.TvSubscription != null)
            {
                Tv = new TvSubscriptionViewModel
                {
                    Name = bill.Package.TvSubscription.Name,
                    Total = bill.Package.TvSubscription.Cost.Value + bill.SkyStore.Summary.Total.Value,
                    Rentals = bill.SkyStore.Rentals.Select(x => new SkyStorePurchaseViewModel { Title = x.Movie.Title, Cost = x.Cost }),
                    BuyAndKeep = bill.SkyStore.BuyAndKeep.Select(x => new SkyStorePurchaseViewModel { Title = x.Movie.Title, Cost = x.Cost })
                };
            }

            if (bill.Package.TalkSubscription != null)
            {
                Talk = new TalkSubscriptionViewModel
                {
                    Name = bill.Package.TalkSubscription.Name,
                    Total = bill.Package.TalkSubscription.Cost.Value + bill.CallCharges.Summary.Total.Value,
                    Charges = bill.CallCharges.Calls.Select(x => new CallChargeViewModel { Number = x.Number, Duration = x.Duration, Cost = x.Cost })
                };
            }

            if (bill.Package.BroadbandSubscription != null)
            {
                Broadband = new BroadbandSubscriptionViewModel
                {
                    Name = bill.Package.BroadbandSubscription.Name,
                    Total = bill.Package.BroadbandSubscription.Cost
                };
            }

            SubTotal = bill.Summary.SubTotal;
            Total = bill.Summary.Total;
            Adjustment = bill.Summary.Adjustment;
        }
    }

    public class TvSubscriptionViewModel
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<SkyStorePurchaseViewModel> Rentals { get; set; }
        public IEnumerable<SkyStorePurchaseViewModel> BuyAndKeep { get; set; }
    }

    public class SkyStorePurchaseViewModel
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
    }

    public class TalkSubscriptionViewModel
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<CallChargeViewModel> Charges { get; set; }
    }

    public class CallChargeViewModel
    {
        public string Number { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Cost { get; set; }
    }

    public class BroadbandSubscriptionViewModel
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
    }
}
