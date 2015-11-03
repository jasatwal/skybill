using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    [TestClass]
    public class BillingServiceTests
    {
        [TestMethod]
        public async Task Find_MapValidJsonObject_ShouldPass()
        {
            // Arrange
            var client = new Mock<IJsonClient>();
            var jsonObject = SampleData.GenerateValidJsonObject();
            client.Setup(x => x.Get<RootObjectDto>(It.IsAny<string>())).Returns(Task.FromResult(jsonObject));

            var service = new BillingService(client.Object, "http://some-end-point");
            var accountNumber = new CustomerAccountNumber("1234567890");

            // Act
            var bill = await service.Find(accountNumber);

            // Assert
            Assert.IsNotNull(bill);
            Assert.AreEqual(jsonObject.statement.generated, bill.Generated);
            Assert.AreEqual(jsonObject.statement.due, bill.Due);
            Assert.AreEqual(jsonObject.statement.period.from, bill.Period.From);
            Assert.AreEqual(jsonObject.statement.period.to, bill.Period.To);
            
        }


    }
}
