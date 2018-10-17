using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IRequestService
    {
        Task<string> GetDataFromAPI(string url);
        //Task<TResult> PostData();
    }
}
