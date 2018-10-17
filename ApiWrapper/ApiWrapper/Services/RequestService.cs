using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public class RequestService : IRequestService
    {
        private string _token;

        public RequestService(IConfiguration configuration)
        {
            _token = configuration["TripletexApi:token"];
        }
        public async Task<string> GetDataFromAPI(string url)
        {
            var token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_token}"));
            string response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + token64);

                //to avoid ssl errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                response = await client.GetStringAsync(url);
            }

            return response;
        }
    }
}
