using System.Threading.Tasks;

namespace Sky
{
    public interface IHttpClient
    {
        Task<string> GetString(string endpoint);
    }
}