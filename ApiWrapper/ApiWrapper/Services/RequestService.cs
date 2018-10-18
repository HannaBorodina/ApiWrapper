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
        private string _token64;
        private string _url;

        public RequestService(IConfiguration configuration)
        {
            var tokenFromConfig = configuration["TripletexApi:token"];
            _token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{tokenFromConfig}"));
            _url = configuration["TripletexApi:url"];
        }
        public async Task<string> GetDataFromAPI(string url)
        {            
            string response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + _token64);

                //to avoid ssl errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                response = await client.GetStringAsync(url);
            }

            return response;
        }

        public async Task<string> PostDataToApi(string data)
        {
            HttpResponseMessage message;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + _token64);

                //to avoid ssl errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                var body = new StringContent(data, Encoding.UTF8, "application/json");
                message = await client.PostAsync(_url, body);
            }

            var result = message.StatusCode == HttpStatusCode.Created ? "ok" : null;
            return result;
        }
    }
}
