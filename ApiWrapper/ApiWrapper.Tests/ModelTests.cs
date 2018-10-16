using ApiWrapper.Models;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace ApiWrapper.Tests
{
    public class ModelTests
    {
        [Theory(DisplayName = "Should deserialize without exceptions")]
        [InlineData("Customer.json")]
        [InlineData("Invoice.json")]
        public void Deserialization(string fileName)
        {
            var path = $"..\\netcoreapp2.1\\Data\\{fileName}";
            string jsonData;

            using (StreamReader sr = new StreamReader(path))
            {
                jsonData = sr.ReadToEnd();
            }

            Assert.NotNull(jsonData);

            if (fileName.Contains("Customer"))
            {
                var customer = JsonConvert.DeserializeObject<Customer>(jsonData);

                Assert.IsType<Customer>(customer);
            }
            else if (fileName.Contains("Invoice"))
            {
                var customer = JsonConvert.DeserializeObject<Invoice>(jsonData);

                Assert.IsType<Invoice>(customer);
            }

        }


    }
}
