
using System;
using System.Net.Http;
using System.Web.Http;

namespace Travo.Controllers
{
    public class StatusController : TravoApiController
    {
        [Route("~/status"), HttpGet]
        public HttpResponseMessage GetStatus()
        {
            return TravoOk();
        }
    }
}
