using ApiWrapper.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiWrapper.Tests
{
    public class IntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private string _projectDir;

        public IntegrationTests()
        {
            _projectDir = Environment.CurrentDirectory;
            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder()
                .SetBasePath(_projectDir)
                .AddJsonFile("appsettings.json")
                .Build()
    )
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory(DisplayName ="get response from api GET")]
        [InlineData("invoice?invoiceDateFrom=2018-01-01&invoiceDateTo=2018-10-01")]
        public async Task CheckGetInvoiceEndpoint(string url)
        {           
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var responseFromApi = JsonConvert.DeserializeObject<WrapperResponse>(responseString);

            Assert.Equal("true", responseFromApi.Success);
            Assert.Null(responseFromApi.Error);
        }

        [Theory(DisplayName = "get response from api POST", Skip ="Not implemented")]
        [InlineData("invoice")]
        public async Task CheckPostInvoiceEndpoint(string url)
        {
            throw new NotImplementedException();
        }
    }
}
