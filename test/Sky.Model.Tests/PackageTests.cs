using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sky
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTvTalkAndBroadbandSubscriptions_ShouldFail()
        {
            new Package(null, null, null, new Money(0M));
        }

        [TestMethod]
        public void Ctor_NullTvAndTalk_ShouldPass()
        {
            new Package(null, null, new Subscription("Broadband", new Money(10M)), new Money(0M));
        }

        [TestMethod]
        public void Ctor_NullTvAndBroadband_ShouldPass()
        {
            new Package(null, new Subscription("Talk", new Money(10M)), null, new Money(0M));
        }

        [TestMethod]
        public void Ctor_NullTalkAndBroadband_ShouldPass()
        {
            new Package(new Subscription("TV", new Money(10M)), null, null, new Money(0M));
        }

        [TestMethod]
        public void Adjustment_PackageValue20AndTotalOf10_AdjustmentShouldBeNegative10()
        {
            var package = new Package(
                new Subscription("TV", new Money(10M)),
                new Subscription("Talk", new Money(5M)),
                new Subscription("Broadband", new Money(5M)), 
                new Money(10M));

            Assert.AreEqual(new Money(-10M), package.Summary.Adjustment);
        }
    }
}
