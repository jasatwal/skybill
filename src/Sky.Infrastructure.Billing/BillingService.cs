using Newtonsoft.Json;
using Sky.Billing;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    public class BillingService : IBillingService
    {
        private readonly IHttpClient client;
        private readonly JsonConverter[] converters;
        private readonly string endpoint;

        public BillingService(IHttpClient client, JsonConverter[] converters, string endpoint)
        {
            Check.Argument.IsNotNull(client, nameof(client));
            Check.Argument.IsNotNull(converters, nameof(converters));
            Check.Argument.IsNotNullOrWhiteSpace(endpoint, nameof(endpoint));

            this.client = client;
            this.converters = converters;
            this.endpoint = endpoint;
        }

        public Task<Bill> Find(CustomerAccountNumber customer)
        {
            Check.Argument.IsNotNull(customer, nameof(customer));

            return client.GetString(endpoint)
                .ContinueWith(x => JsonConvert.DeserializeObject<Bill>(x.Result, converters));
        }
    }
}
