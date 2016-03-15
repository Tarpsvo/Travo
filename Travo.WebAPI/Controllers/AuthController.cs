using System.Web.Http;
using Travo.Domain.DTO;

namespace Travo.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : TravoApiController
    {
        [Route("login"), HttpPost]
        public IHttpActionResult Login(LoginDTO vm)
        {
            if (!ModelState.IsValid) {
                return Error(ModelState);
            }

            return Ok();
        }

        [Route("register"), HttpPost]
        public IHttpActionResult Register(RegisterDTO vm)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState);
            }

            return Ok();
        }
    }
}
