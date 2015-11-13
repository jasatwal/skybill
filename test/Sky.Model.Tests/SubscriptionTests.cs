using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
{
    [TestClass]
    public class SubscriptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTypeAndNameAndCost_ShouldFail()
        {
            new Subscription(null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_EmptyTypeAndName_ShouldFail()
        {
            new Subscription("", "", new Money(10M));
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void Ctor_WhiteSpaceName_ShouldFail()
        //{
        //    new Subscription(" ", new Money(10M));
        //}

        //[TestMethod]
        //public void Ctor_ValidNameAndCost_ShouldPass()
        //{
        //    new Subscription("Family", new Money(10M));
        //}
    }
}
