using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Travo.Controllers
{
    public class ErrorActionResult: IHttpActionResult
    {
        // Main
        public string Message { get; set; }
        public List<string> Detail { get; set; }

        public ErrorActionResult(ModelStateDictionary ms)
        {
            Message = "Request data was not valid.";
            Detail = TravoApiController.GetModelStateErrors(ms);
        }

        // IHttpActionResult
        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Message = this.Message, Detail = this.Detail }));
            response.RequestMessage = Request;
            return response;
        }
    }
}