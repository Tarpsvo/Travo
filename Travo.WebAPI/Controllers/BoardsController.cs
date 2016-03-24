using System.Web.Http;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("boards"), Authorize]
    public class BoardsController : TravoApiController
    {
        private IBoardServices _boardServices;

        public BoardsController(IBoardServices boardServices)
        {
            _boardServices = boardServices;
        }

        [Route("{boardId:int}/withTagsAndTasks"), HttpGet]
        public IHttpActionResult GetBoardTagsWithTasks(int boardId)
        {
            var tagsWithTasks = _boardServices.GetTagsWithTasksForBoard(UserId, boardId);
            return Json(tagsWithTasks);
        }
    }
}
