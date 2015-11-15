using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sky.Billing.Statistics
{
    [TestClass]
    public class SkyStoreStatisticsTests
    {
        [TestMethod]
        public void GetChargesValueTest()
        {
            // Arrange
            var rentals = new[] 
            {
                new SkyStorePurchase(new SkyStoreMovie("50 Shades of Grey"), new Money(4.99M))
            };
            var buyAndKeep = new[] 
            {
                new SkyStorePurchase(new SkyStoreMovie("That's what she said"), new Money(9.99M)),
                new SkyStorePurchase(new SkyStoreMovie("Broke back mountain"), new Money(9.99M))
            };
            var bill = new SkyStoreBill(rentals, buyAndKeep, new Money(24.97M));
            var stats = new SkyStoreStatistics(bill);

            // Act
            var results = stats.GetChargesValue();

            // Assert
            Assert.AreEqual(2, results.Count());
            Assert.AreEqual(rentals.Sum(), results.ElementAt(0).Value);
            Assert.AreEqual(buyAndKeep.Sum(), results.ElementAt(1).Value);
        }
    }
}