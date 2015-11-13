using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Sky.Billing
{
    [TestClass]
    public class CallChargesBillTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullCallsArg_ShouldFail()
        {
            new CallChargesBill(null, Money.Zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTotalArg_ShouldFail()
        {
            new CallChargesBill(Enumerable.Empty<CallCharge>(), null);
        }
    }
}
