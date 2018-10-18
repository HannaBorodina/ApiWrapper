using ApiWrapper.Models;
using ApiWrapper.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ApiWrapper.Tests
{
    public class ServiceTests
    {
        [Fact(DisplayName = "generate error response")]
        public async Task ShouldGenerateError()
        {
            var generator = new ResponseGenerator();

            var excMess = "exception";
            var result = await generator.GenerateResponse(excMessage: excMess);

            Assert.Null(result.Value);
            Assert.Equal(excMess, result.Error);
            Assert.Equal("false", result.Success);
        }

        [Fact(DisplayName ="generate empty response")]
        public async Task ShouldGenerateEmptyObj()
        {
            var generator = new ResponseGenerator();

            var result = await generator.GenerateResponse();

            Assert.Null(result.Value);
            Assert.Null(result.Error);
            Assert.Null(result.Success);
        }

        [Fact(DisplayName = "generate success response")]
        public async Task ShouldGenerateSuccess()
        {
            var generator = new ResponseGenerator();

            var path = $"..\\netcoreapp2.1\\Data\\Invoice.json";
            string jsonData;

            using (StreamReader sr = new StreamReader(path))
            {
                jsonData = sr.ReadToEnd();
            }

            var result = await generator.GenerateResponse(value: jsonData);

            Assert.NotNull(result.Value);
            Assert.Null(result.Error);
            Assert.Equal("true", result.Success);
        }

        [Theory(DisplayName = "get data from api by request service")]
        [InlineData("https://tripletex.no/v2/invoice?invoiceDateFrom=2018-01-01&invoiceDateTo=2018-10-01&count=1")]
        public async Task GetRequest(string url)
        {
            var configuration = new Mock<IConfiguration>();
            configuration.SetupGet(m => m["TripletexApi:token"]).Returns("0:908140ea-bd1b-46a9-a9ed-65c5fac4dda3");
            
            var requestService = new RequestService(configuration.Object);

            var response = await requestService.GetDataFromAPI(url);

            Assert.NotNull(response);

            var invoice = JsonConvert.DeserializeObject<Invoice>(response);

            Assert.NotNull(invoice);
        }
    }
}
