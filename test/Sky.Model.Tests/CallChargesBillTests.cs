using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
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

        [TestMethod]
        public void Adjustment_CallsWithTotalCost10AndCost5_AdjustmentShouldBeNegative5()
        {
            var bill = new CallChargesBill(
                    new[] {
                        new CallCharge("01234567890", TimeSpan.Zero, 5M),
                        new CallCharge("01234567890", TimeSpan.Zero, 5M)
                    }, 5M);

            Assert.AreEqual(new Money(-5M), bill.Summary.Adjustment);
        }
    }
}
