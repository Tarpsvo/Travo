using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("boards"), Authorize]
    public class BoardsController : TravoApiController
    {
        private IBoardServices _boardServices;
        private ITagServices _tagServices;

        public BoardsController(IBoardServices boardServices, ITagServices tagServices)
        {
            _boardServices = boardServices;
            _tagServices = tagServices;
        }

        [Route("{boardId:int}/withTagsAndTasks"), HttpGet]
        public HttpResponseMessage GetBoardTagsWithTasks(int boardId)
        {
            var tagsWithTasks = _boardServices.GetTagsWithTasksForBoard(UserId, boardId);
            return TravoOk(tagsWithTasks);
        }

        [Route("{boardId:int}/tags"), HttpPost]
        public HttpResponseMessage CreateNewTag(int boardId, [FromBody] TagDTO tagDTO)
        {
            var tag = _tagServices.AddNewTag(UserId, boardId, tagDTO);
            return TravoOk(tag);
        }
    }
}
