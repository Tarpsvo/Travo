using System.Web.Http;
using Travo.ViewModels.Team;

namespace Travo.Controllers
{
    [RoutePrefix("teams"), Authorize]
    public class TeamsController: ApiController
    {
        [Route(""), HttpGet]
        public IHttpActionResult GetAllUsersTeamsAndBoards()
        {
            return Ok(new { Teams = new TeamGetVM { Id = 12, Name = "Team", Description = "Desc", Created = 1232133454 } });
        }
    }
}