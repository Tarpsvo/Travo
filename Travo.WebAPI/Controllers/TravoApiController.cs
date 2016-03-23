using Microsoft.AspNet.Identity;
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
    }
}