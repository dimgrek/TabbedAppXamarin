using System.Threading.Tasks;

namespace TabbedAppXamarin.Services.Networking
{
    public interface IRestClient
    {
        Task<byte[]> GetBytes(string uri);
    }
}
