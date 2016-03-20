using System.Threading.Tasks;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : TravoApiController
    {
        private IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost]
        public async Task<IHttpActionResult> Register(UserDTO userDTO)
        {
            var result = await _accountServices.Register(userDTO);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
