using Newtonsoft.Json;
using Sky.Infrastructure;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sky.Web.UI
{
    public class JsonClient : IJsonClient
    {
        public async Task<T> Get<T>(string endpoint)
        {
            using (var http = new HttpClient())
                return JsonConvert.DeserializeObject<T>(await http.GetStringAsync(endpoint));
        }
    }
}
