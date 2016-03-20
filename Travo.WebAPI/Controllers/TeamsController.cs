using System.Web.Http;
using Travo.BLL.DTO;

namespace Travo.Controllers
{
    [RoutePrefix("teams"), Authorize]
    public class TeamsController: TravoApiController
    {
        [Route(""), HttpGet]
        public IHttpActionResult GetAllUsersTeamsAndBoards()
        {
            return Ok(new { Teams = new TeamDTO { Id = 12, Name = "Team", Description = "Desc", Created = 1232133454 } });
        }
    }
}