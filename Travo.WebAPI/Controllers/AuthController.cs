using System.Web.Http;
using Travo.Controllers.Main;
using Travo.ViewModels.Auth;

namespace Travo.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : TravoApiController
    {
        [Route("login"), HttpPost]
        public IHttpActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid) {
                return Error(ModelState);
            }

            return Ok();
        }

        [Route("register"), HttpPost]
        public IHttpActionResult Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState);
            }

            return Ok();
        }
    }
}
