using Sky.Billing;
using Sky.Billing.Statistics;
using System.Collections.Generic;

namespace Sky.Web.UI.ViewModels.Account
{
    public class BillWithStatisticsViewModel
    {
        public Bill Bill { get; set; }
        public IEnumerable<CalledFrequency> CalledFrequency { get; set; }
        public IEnumerable<SkyStoreChargeValue> SkyStoreChargesValue { get; set; }
    }
}
