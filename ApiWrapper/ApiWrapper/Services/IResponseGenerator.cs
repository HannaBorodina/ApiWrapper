using ApiWrapper.Models;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IResponseGenerator
    {
        Task<WrapperResponse> GenerateResponse(string value = null, string excMessage = null);
    }
}
