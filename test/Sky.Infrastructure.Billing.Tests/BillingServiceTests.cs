using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Sky.Web.JsonConverters;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    [TestClass]
    public class BillingServiceTests
    {
        [TestMethod]
        public async Task Find_JsonBillWithoutCallCharges_ShouldReturnBillWithNullCallChargesAndNotNullSkyStore()
        {
            // Arrange
            var client = new Mock<IHttpClient>();
            client.Setup(x => x.GetString(It.IsAny<string>())).Returns(Task.FromResult(SampleData.BillWithoutCallCharges()));
            var converters = new JsonConverter[] { new MoneyJsonConverter(), new SkyStoreMovieJsonConverter(), new TelephoneNumberJsonConverter() };

            var service = new BillingService(client.Object, converters, "http://some-end-point");
            var accountNumber = new CustomerAccountNumber("1234567890");

            // Act
            var bill = await service.Find(accountNumber);

            // Assert
            Assert.IsNotNull(bill);
            Assert.IsNull(bill.CallCharges);
            Assert.IsNotNull(bill.SkyStore);
        }
    }
}
