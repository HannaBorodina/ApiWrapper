using ApiWrapper.Models;
using System.IO;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IWrapperHandler
    {
        Task<WrapperResponse> HandleGetRequest(string url);
        Task<WrapperResponse> HandlePostRequest(string data);
        Task<string> GetParams(string from, string to);
        Task<string> GetBody(Stream stream);
    }
}
