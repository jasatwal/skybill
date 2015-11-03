using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sky
{
    [TestClass]
    public class PeriodTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_FromIsAfterTo_ShouldFail()
        {
            new Period(DateTime.Today.AddDays(1), DateTime.Today);
        }

        [TestMethod]
        public void Ctor_FromIsBeforeTo_ShouldPass()
        {
            new Period(DateTime.Today, DateTime.Today.AddDays(1));
        }
    }
}
