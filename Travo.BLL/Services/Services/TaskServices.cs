using BLL;
using System;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
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
            if (taskDTO.TagId == 0) throw TravoExceptions.NotFound();

            var access = _userRepository.UserHasAccessToTag(userId, taskDTO.TagId ?? 0); // TODO Proper error handling?
            if (!access) throw new UnauthorizedAccessException();

            var task = Factories.TaskFactory.createTaskFromDTO(taskDTO);
            task.CreatedByUserId = userId;
            var savedTask = _taskRepository.Add(task);
            _taskRepository.Save();
            return TaskFactory.createReturnMinimalDTO(savedTask);
        }

        public TaskDTO GetTask(string userId, int taskId)
        {
            var access = _userRepository.UserHasAccessToTask(userId, taskId); // TODO Proper error handling?
            if (!access) throw TravoExceptions.Forbidden();

            var task = _taskRepository.GetById(taskId);
            if (task == null) throw TravoExceptions.NotFound();

            return TaskFactory.createReturnDTO(task); 
        }

        public void UpdateTask(string userId, TaskDTO taskDTO)
        {
            var access = _userRepository.UserHasAccessToTask(userId, taskDTO.Id); // TODO Proper error handling?
            if (!access) throw TravoExceptions.Forbidden();

            var task = _taskRepository.GetById(taskDTO.Id);
            if (taskDTO.Title != null) task.Title = taskDTO.Title;
            if (taskDTO.Description != null) task.Description = taskDTO.Description;
            _taskRepository.Save();
        }
    }
}
