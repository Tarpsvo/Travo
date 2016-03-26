using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Travo.Controllers
{
    public class TravoApiController: ApiController
    {
        protected string UserId
        {
            get
            {
                return HttpContext.Current.User.Identity.GetUserId();
            }
        }

        protected HttpResponseMessage TravoOk()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected HttpResponseMessage TravoOk(object body)
        {
            return Request.CreateResponse(HttpStatusCode.OK, body, Request.GetConfiguration());
        }

        protected HttpResponseMessage TravoBadRequest()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}