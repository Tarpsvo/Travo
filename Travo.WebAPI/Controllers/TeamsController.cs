using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("teams"), Authorize]
    public class TeamsController: TravoApiController
    {
        private ITeamServices _teamServices;

        public TeamsController(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        [Route("withBoards"), HttpGet]
        public IHttpActionResult GetTeamsWithBoards()
        {
            var teamsWithBoards = _teamServices.GetTeamsWithBoardsForUser(UserId);
            return Json(teamsWithBoards);
        }
    }
}