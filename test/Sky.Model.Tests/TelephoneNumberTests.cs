using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
{
    [TestClass]
    public class TelephoneNumberTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullValue_ShouldFail()
        {
            new TelephoneNumber(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_ContainsNonNumericCharacter_ShouldFail()
        {
            new TelephoneNumber("012e4s6tbqo");
        }

        [TestMethod]
        public void Ctor_NumericValue_ShouldPass()
        {
            new TelephoneNumber("01234567890");
        }
    }
}
