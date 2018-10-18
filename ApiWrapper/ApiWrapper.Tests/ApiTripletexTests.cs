using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiWrapper.Tests
{
    public class ApiTripletexTests
    {
        /*curl -X GET --header 'Accept: application/json' 
        * --header 'Authorization: Basic MDo5MDgxNDBlYS1iZDFiLTQ2YTktYTllZC02NWM1ZmFjNGRkYTM=' 
        * 'https://tripletex.no/v2/invoice?invoiceDateFrom=2018-01-01&invoiceDateTo=2018-10-01&count=1'*/

        [Theory(DisplayName = "Should set connection and get data from tripletex api without exceptions")]
        [InlineData("2018-01-01", "2018-10-01", "2", "https://tripletex.no/v2/invoice", "0:908140ea-bd1b-46a9-a9ed-65c5fac4dda3")]
        public async Task GetDataFromApi(string dateFrom, string dateTo, string count, string url, 
            string sessionToken)
        {
            var tokenFromSwagger = "MDo5MDgxNDBlYS1iZDFiLTQ2YTktYTllZC02NWM1ZmFjNGRkYTM=";
            var token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{sessionToken}"));

            Assert.Equal(tokenFromSwagger, token64);

            var parameters = $"invoiceDateFrom={dateFrom}&invoiceDateTo={dateTo}&count={count}";
            string response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + tokenFromSwagger);

                //to avoid ssl errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                response = await client.GetStringAsync($"{url}?{parameters}");
            }

            Assert.NotNull(response);

        }

        [Theory(DisplayName = "Should set connection and post data to tripletex api without exceptions")]
        [InlineData("AddInvoice.json", "https://tripletex.no/v2/invoice", "0:908140ea-bd1b-46a9-a9ed-65c5fac4dda3")]
        public async Task PostDataToApi(string fileName, string url, string sessionToken)
        {
            string responseString;
            var path = $"..\\netcoreapp2.1\\Data\\{fileName}";
            string jsonData;

            using (StreamReader sr = new StreamReader(path))
            {
                jsonData = sr.ReadToEnd();
            }
            var _token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{sessionToken}"));

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + _token64);

                //to avoid ssl errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, body);

                responseString = await response.Content.ReadAsStringAsync();
            }

            //Assert.NotNull(responseString);
        }
    }
}
