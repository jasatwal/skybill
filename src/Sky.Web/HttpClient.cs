using System;
using System.Threading.Tasks;

namespace Sky.Web
{
    public class HttpClient : IHttpClient, IDisposable
    {
        private readonly System.Net.Http.HttpClient http;

        public HttpClient()
        {
            http = new System.Net.Http.HttpClient();
        }

        public Task<string> GetString(string endpoint)
        {
            return http.GetStringAsync(endpoint);
        }

        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Disposing(bool disposing)
        {
            if (disposing)
                http.Dispose();
        }
    }
}
