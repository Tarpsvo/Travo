using System.Web.Http;
using Travo.ViewModels.Auth;

namespace Travo.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiController
    {
        [Route("login"), HttpPost]
        public IHttpActionResult Login(LoginVM vm)
        {
            // TODO: Replace with real auth
            if (vm == null || !(vm.Email == "test" && vm.Password == "test"))
            {
                return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            return Ok(new { success = true });
        }

        [Route("register"), HttpPost]
        public IHttpActionResult Register(RegisterVM vm)
        {
            // TODO: Replace with real auth
            return Ok(new { success = false, message = "Register." });
        }
    }
}
