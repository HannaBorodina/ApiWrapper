using System;
using System.Threading.Tasks;
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
                var result = await _responseGenerator.GenerateResponse(excMessage: ex.Message);
                return StatusCode(500, result);
            }

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
