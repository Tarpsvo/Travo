using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travo.BLL.DTO;
using Travo.BLL.Services;

namespace Travo.Controllers
{
    [RoutePrefix("tasks"), Authorize]
    public class TasksController : TravoApiController
    {
        private ITaskServices _taskServices;

        public TasksController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [Route(""), HttpPost]
        public HttpResponseMessage AddTask([FromBody] TaskDTO taskDTO)
        {
            return TravoOk(_taskServices.AddTask(UserId, taskDTO));
        }
    }
}
