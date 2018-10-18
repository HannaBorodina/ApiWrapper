using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ApiWrapper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiWrapper.Services
{
    public class WrapperHandler : IWrapperHandler
    {
        private IRequestService _requestService;
        private IDBService _dbService;
        private IResponseGenerator _responseGenerator;
        private string _url;

        public WrapperHandler(IRequestService requestService, IDBService dbService,
            IResponseGenerator responseGenerator, IConfiguration configuration)
        {
            _requestService = requestService;
            _dbService = dbService;
            _responseGenerator = responseGenerator;
            _url = configuration["TripletexApi:url"];
        }

        public async Task<string> GetBody(Stream stream)
        {
            string json;

            using (var readStream = new StreamReader(stream, Encoding.UTF8))
            {
                json = await readStream.ReadToEndAsync();
            }

            return json;
        }

        public async Task<string> GetParams(string from, string to)
        {
            var result = await Task.Run(() =>
            {
                //TODO: make better validation checks based on types
                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                    throw new Exception("One of the required parameters is missed : invoiceDateFrom, invoiceDateTo");

                var parameters = $"{_url}?invoiceDateFrom={from}&invoiceDateTo={to}";
                return parameters;
            });

            return result;
        }

        public async Task<WrapperResponse> HandleGetRequest(string url)
        {
            var dataFromAPI = await _requestService.GetDataFromAPI(url);
            await _dbService.AddDataToDB<Invoice>(dataFromAPI);

            var result = await _responseGenerator.GenerateResponse(value: dataFromAPI);
            return result;

        }

        public async Task<WrapperResponse> HandlePostRequest(string data)
        {
            var response = await _requestService.PostDataToApi(data);
            if (string.IsNullOrEmpty(response))
                throw new Exception("Can't create invoice in tripletex api");

            await _dbService.AddDataToDB<InvoiceValue>(data);

            var result = await _responseGenerator.GenerateResponse(created: "Invoice created");
            return result;
        }
    }
}
