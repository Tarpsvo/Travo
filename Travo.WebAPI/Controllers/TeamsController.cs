using System.Net.Http;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("teams"), Authorize]
    public class TeamsController: TravoApiController
    {
        private ITeamServices _teamServices;
        private IBoardServices _boardServices;

        public TeamsController(ITeamServices teamServices, IBoardServices boardServices)
        {
            _teamServices = teamServices;
            _boardServices = boardServices;
        }

        [Route("withBoards"), HttpGet]
        public HttpResponseMessage GetTeamsWithBoards()
        {
            var teamsWithBoards = _teamServices.GetTeamsWithBoardsForUser(UserId);
            return TravoOk(teamsWithBoards);
        }

        [Route("{teamId:int}/boards"), HttpPost]
        public HttpResponseMessage CreateNewBoard(int teamId, [FromBody] BoardDTO boardDTO)
        {
            var board = _boardServices.CreateBoard(UserId, teamId, boardDTO);
            return TravoOk(board);
        }
    }
}