using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sky
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Value_InitWith17Point5_ShouldBe17Point5()
        {
            var m = new Money(17.5M);

            Assert.AreEqual(17.5M, m.Value);
        }

        [TestMethod]
        public void Add_22Point47Add11Point9_ShouldBe34Point37()
        {
            var m1 = new Money(22.47M);
            var m2 = new Money(11.9M);

            var result = m1.Add(m2);

            Assert.AreEqual(34.37M, result.Value);
        }

        [TestMethod]
        public void Subtract_22Point47Subtract11Point9_ShouldBe10Point57()
        {
            var m1 = new Money(22.47M);
            var m2 = new Money(11.9M);

            var result = m1.Subtract(m2);

            Assert.AreEqual(10.57M, result.Value);
        }
    }
}