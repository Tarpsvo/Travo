using System.Web.Http;
using Travo.Models.Authentication;

namespace Travo.Controllers
{
    public class AuthenticationController : ApiController
    {
        [Route("authenticate")]
        public IHttpActionResult Authenticate(AuthenticationViewModel vm)
        {
            /* REPLACE THIS WITH REAL AUTHENTICATION
            ----------------------------------------------*/
            if (vm == null || !(vm.Email == "test" && vm.Password == "test"))
            {
                return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            return Ok(new { success = true });
        }
    }
}
