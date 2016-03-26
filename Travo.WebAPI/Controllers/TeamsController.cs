using System.Net.Http;
using System.Web.Http;
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
        public HttpResponseMessage GetTeamsWithBoards()
        {
            var teamsWithBoards = _teamServices.GetTeamsWithBoardsForUser(UserId);
            return TravoOk(teamsWithBoards);
        }
    }
}