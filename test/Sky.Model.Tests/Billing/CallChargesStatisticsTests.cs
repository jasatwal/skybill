using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sky.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Billing
{
    [TestClass()]
    public class CallChargesStatisticsTests
    {
        [TestMethod()]
        public void CallChargesStatisticsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCalledFrequencyTest()
        {
            // Arrange
            var charges = new[]
            {
                new CallCharge(new TelephoneNumber("0123456789"), TimeSpan.FromSeconds(19), new Money(.19M)),
                new CallCharge(new TelephoneNumber("0123456789"), TimeSpan.FromSeconds(58), new Money(.58M)),
                new CallCharge(new TelephoneNumber("0123456789"), TimeSpan.FromSeconds(105), new Money(.05M)),
                new CallCharge(new TelephoneNumber("0123456789"), TimeSpan.FromSeconds(44), new Money(.44M)),
                new CallCharge(new TelephoneNumber("0781552266"), TimeSpan.FromSeconds(44), new Money(.44M))
            };
            var bill = new CallChargesBill(charges, charges.Sum());
            var stats = new CallChargesStatistics(bill);

            // Act
            var results = stats.GetCalledFrequency();

            // Assert
            Assert.AreEqual(2, results.Count());
            Assert.AreEqual(new TelephoneNumber("0123456789"), results.ElementAt(0).Number);
            Assert.AreEqual(new TelephoneNumber("0781552266"), results.ElementAt(1).Number);
            Assert.AreEqual(4, results.ElementAt(0).Frequency);
            Assert.AreEqual(1, results.ElementAt(1).Frequency);
        }
    }
}