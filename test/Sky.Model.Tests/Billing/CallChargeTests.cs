using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sky.Billing
{
    [TestClass]
    public class CallChargeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullNumberAndCost_ShouldFail()
        {
            new CallCharge(null, TimeSpan.Zero, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullNumber_ShouldFail()
        {
            new CallCharge(null, TimeSpan.Zero, Money.Zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullCost_ShouldFail()
        {
            new CallCharge(new TelephoneNumber("01234567890"), TimeSpan.Zero, null);
        }
    }
}
