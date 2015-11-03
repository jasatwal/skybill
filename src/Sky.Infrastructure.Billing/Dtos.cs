using System;
using System.Collections.Generic;

namespace Sky.Infrastructure.Billing
{
    public class PeriodDto
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }

    public class StatementDto
    {
        public DateTime generated { get; set; }
        public DateTime due { get; set; }
        public PeriodDto period { get; set; }
    }

    public class SubscriptionDto
    {
        public string type { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }
    }

    public class PackageDto
    {
        public List<SubscriptionDto> subscriptions { get; set; }
        public decimal total { get; set; }
    }

    public class CallDto
    {
        public string called { get; set; }
        public TimeSpan duration { get; set; }
        public decimal cost { get; set; }
    }

    public class CallChargesDto
    {
        public List<CallDto> calls { get; set; }
        public decimal total { get; set; }
    }

    public class RentalDto
    {
        public string title { get; set; }
        public decimal cost { get; set; }
    }

    public class BuyAndKeepDto
    {
        public string title { get; set; }
        public decimal cost { get; set; }
    }

    public class SkyStoreDto
    {
        public List<RentalDto> rentals { get; set; }
        public List<BuyAndKeepDto> buyAndKeep { get; set; }
        public decimal total { get; set; }
    }

    public class RootObjectDto
    {
        public StatementDto statement { get; set; }
        public decimal total { get; set; }
        public PackageDto package { get; set; }
        public CallChargesDto callCharges { get; set; }
        public SkyStoreDto skyStore { get; set; }
    }

}
