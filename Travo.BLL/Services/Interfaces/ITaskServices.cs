using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface ITaskServices
    {
        TaskDTO AddTask(string userId, TaskDTO taskDTO);
        TaskDTO GetTask(string userId, int taskId);
        void UpdateTask(string userId, TaskDTO taskDTO);
    }
}
