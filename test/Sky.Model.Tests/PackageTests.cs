using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullSubscriptionsAndTotalArgs_ShouldFail()
        {
            new PackageBill(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullSubscriptionsArg_ShouldFail()
        {
            new PackageBill(null, Money.Zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTotalArg_ShouldFail()
        {
            new PackageBill(new[] { new Subscription("tv", "Variety with Movies HD", new Money(50M)) }, null);
        }

        [TestMethod]
        public void BreakdownTest()
        {
            Assert.Fail();
        }
    }
}