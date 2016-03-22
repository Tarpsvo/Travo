using System.Threading.Tasks;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("account")]
    public class UserController : TravoApiController
    {
        private IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost]
        public async Task<IHttpActionResult> Register(UserDTO userDTO)
        {
            var result = await _userServices.Register(userDTO);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
