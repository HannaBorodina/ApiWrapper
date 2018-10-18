using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ApiWrapper.Helpers;
using ApiWrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiWrapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IWrapperHandler _handler;
        private IResponseGenerator _responseGenerator;

        public InvoiceController(IWrapperHandler handler, IResponseGenerator responseGenerator)
        {
            _handler = handler;
            _responseGenerator = responseGenerator;
        }

        // GET /invoice
        [HttpGet]
        public async Task<ActionResult> Get(string invoiceDateFrom, string invoiceDateTo)
        {
            try
            {
                var url = await _handler.GetParams(invoiceDateFrom, invoiceDateTo);
                var result = await _handler.HandleGetRequest(url);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = ex.GetaAllMessages();
                var result = await _responseGenerator.GenerateResponse(excMessage: message);
                return StatusCode(500, result);
            }

        }

        // POST /invoice
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            try
            {
                var requestJson = await _handler.GetBody(Request.Body);
                var result = await _handler.HandlePostRequest(requestJson);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = ex.GetaAllMessages();
                var result = await _responseGenerator.GenerateResponse(excMessage: message);
                return StatusCode(500, result);

            }
        }
    }
}
