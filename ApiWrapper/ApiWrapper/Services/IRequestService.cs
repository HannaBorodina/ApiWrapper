using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IRequestService
    {
        Task<string> GetDataFromAPI(string url);
        Task<string> PostDataToApi(string data);
    }
}
