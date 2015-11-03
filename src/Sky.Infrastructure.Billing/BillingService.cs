using System.Linq;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    public class BillingService : IBillingService
    {
        private readonly string endpoint;
        private readonly IJsonClient client;

        public BillingService(IJsonClient client, string endpoint)
        {
            Check.Argument.IsNotNull(client, nameof(client));
            Check.Argument.IsNotNullOrWhiteSpace(endpoint, nameof(endpoint));

            this.client = client;
            this.endpoint = endpoint;
        }

        public async Task<CustomerBill> Find(CustomerAccountNumber customer)
        {
            Check.Argument.IsNotNull(customer, nameof(customer));

            // TODO: Might be possible to map directly to models rather then DTOs using custom JsonConverter impls

            var data = await client.Get<RootObjectDto>(endpoint);

            return new CustomerBill(customer,
                data.statement.generated,
                data.statement.due,
                data.statement.period.Convert(),
                data.package.Convert(),
                new CallChargesBill(
                        data.callCharges.calls.Select(x => x.Convert()), 
                        data.callCharges.total),
                new SkyStoreBill(
                    data.skyStore.rentals.Select(x => x.Convert()), 
                    data.skyStore.buyAndKeep.Select(x => x.Convert()), 
                    data.skyStore.total),
                data.total);
        }
    }
}
