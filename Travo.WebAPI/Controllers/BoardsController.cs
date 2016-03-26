using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage GetBoardTagsWithTasks(int boardId)
        {
            var tagsWithTasks = _boardServices.GetTagsWithTasksForBoard(UserId, boardId);
            return TravoOk(tagsWithTasks);
        }
    }
}
