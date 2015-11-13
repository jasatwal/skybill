using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sky.Billing
{
    [TestClass]
    public class CostingsBreakdownTests
    {
        [TestMethod]
        public void Adjustment_20SubTotalAnd60Total_AdjustmentShouldBe40()
        {
            var summary = new CostingsBreakdown(20M, 60M);

            Assert.AreEqual(new Money(40M), summary.Adjustment);
        }

        [TestMethod]
        public void Adjustment_20SubTotalAnd20Total_AdjustmentShouldBeZero()
        {
            var summary = new CostingsBreakdown(20M, 20M);

            Assert.AreEqual(Money.Zero, summary.Adjustment);
        }

        [TestMethod]
        public void Adjustment_40SubTotalAnd5Total_AdjustmentShouldBeNegative35()
        {
            var summary = new CostingsBreakdown(40M, 5M);

            Assert.AreEqual(new Money(-35M), summary.Adjustment);
        }
    }
}