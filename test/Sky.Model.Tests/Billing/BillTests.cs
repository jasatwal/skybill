using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sky.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Billing
{
    [TestClass]
    public class BillTests
    {
        [TestMethod]
        public void Ctor_NullCallChargesArg_CostingSubTotalIsCalculatedCorrectly()
        {
            // Arrange
            var bill = new Bill(
                    new Statement(
                        new DateTime(2015, 11, 1),
                        new DateTime(2015, 1, 25),
                        new Period(new DateTime(2015, 1, 26), new DateTime(2015, 2, 25))),
                    new PackageBill(new[]
                    {
                        new Subscription("tv", "Variety with Movies HD", new Money(50M)),
                        new Subscription("talk","Sky Talk Anytime", new Money(5M)),
                        new Subscription("broadband", "Fibre Unlimited", new Money(16.40M))
                    }, new Money(71.4M)),
                    null, // CallCharges
                    new SkyStoreBill(
                            new[]
                            {
                                new SkyStorePurchase(new SkyStoreMovie("50 Shades of Grey"), new Money(4.99M))
                            },
                            new[]
                            {
                                new SkyStorePurchase(new SkyStoreMovie("That's what she said"), new Money(9.99M)),
                                new SkyStorePurchase(new SkyStoreMovie("Broke back mountain"), new Money(9.99M))
                            },
                            new Money(24.97M)
                    ),
                    new Money(76.39M));

            // Assert
            Assert.AreEqual(new Money(96.37M), bill.Costings.SubTotal);
        }

        [TestMethod]
        public void Ctor_NullCallChargesAndSkyStoreArg_CostingSubTotalIsCalculatedCorrectly()
        {
            // Arrange
            var bill = new Bill(
                    new Statement(
                        new DateTime(2015, 11, 1),
                        new DateTime(2015, 1, 25),
                        new Period(new DateTime(2015, 1, 26), new DateTime(2015, 2, 25))),
                    new PackageBill(new[]
                    {
                        new Subscription("tv", "Variety with Movies HD", new Money(50M)),
                        new Subscription("talk","Sky Talk Anytime", new Money(5M)),
                        new Subscription("broadband", "Fibre Unlimited", new Money(16.40M))
                    }, new Money(71.4M)),
                    null, // CallCharges
                    null, // SkyStore
                    new Money(51.42M));

            // Assert
            Assert.AreEqual(new Money(71.4M), bill.Costings.SubTotal);
        }
    }
}