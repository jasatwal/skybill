using System.Threading.Tasks;

namespace Sky.Infrastructure
{
    public interface IJsonClient
    {
        Task<T> Get<T>(string endpoint);
    }
}