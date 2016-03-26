using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("user")]
    public class UserController : TravoApiController
    {
        private IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost]
        public async Task<HttpResponseMessage> Register(UserDTO userDTO)
        {
            var result = await _userServices.Register(userDTO);
            if (result) return TravoOk();
            else return TravoBadRequest();
        }
    }
}
