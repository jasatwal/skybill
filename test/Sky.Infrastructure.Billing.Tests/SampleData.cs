using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    public static class SampleData
    {
        public static RootObjectDto GenerateValidJsonObject()
        {
            return new RootObjectDto
            {
                statement = new StatementDto
                {
                    generated = new DateTime(2015, 1, 11),
                    due = new DateTime(2015, 1, 25),
                    period = new PeriodDto
                    {
                        from = new DateTime(2015, 1, 26),
                        to = new DateTime(2015, 2, 25),
                    }
                },
                total = 136.03M,
                package = new PackageDto
                {
                    subscriptions = new List<SubscriptionDto>
                    {
                        new SubscriptionDto { type = "tv", name = "Variety with Movies HD", cost = 50M },
                        new SubscriptionDto { type = "talk", name = "Sky Talk Anytime", cost = 5M },
                        new SubscriptionDto { type = "broadband", name = "Fibre Unlimited", cost = 16.40M }
                    },
                    total = 71.40M
                },
                callCharges = new CallChargesDto
                {
                    calls = new List<CallDto>
                    {
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "07716393769", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M },
                        new CallDto { called = "02074351359", duration = TimeSpan.Parse("00:23:03"), cost = 2.13M }
                    },
                    total = 59.64M
                },
                skyStore = new SkyStoreDto
                {
                    rentals = new List<RentalDto>
                    {
                        new RentalDto { title = "50 Shades of Grey", cost = 4.99M }
                    },
                    buyAndKeep = new List<BuyAndKeepDto>
                    {
                        new BuyAndKeepDto { title = "That's what she said", cost = 9.99M },
                        new BuyAndKeepDto { title = "Broke back mountain", cost = 9.99M }
                    },
                    total = 24.97M
                }
            };
        }
    }
}
