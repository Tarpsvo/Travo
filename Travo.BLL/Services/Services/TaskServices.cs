using System;
using System.Threading.Tasks;
using Travo.BLL.DTO;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class TaskServices : ITaskServices
    {
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;

        public TaskServices(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public TaskDTO AddTask(string userId, TaskDTO taskDTO)
        {
            if (taskDTO.TagId == 0)
            {
                // TODO Add proper exceptions
                throw new IndexOutOfRangeException();
            }

            var access = _userRepository.UserHasAccessToTag(userId, taskDTO.TagId ?? 0); // TODO Proper error handling?
            if (!access)
            {
                throw new UnauthorizedAccessException();
            }

            var task = Factories.TaskFactory.createTaskFromDTO(taskDTO);
            task.CreatedByUserId = userId;
            var savedTask = _taskRepository.Add(task);
            _taskRepository.Save();
            return Factories.TaskFactory.createReturnMinimalDTO(savedTask);
        }
    }
}
