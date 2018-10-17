using ApiWrapper.Models;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IWrapperHandler
    {
        Task<WrapperResponse> HandleGetRequest(string url);
        Task<string> GetParams(string from, string to);
    }
}
