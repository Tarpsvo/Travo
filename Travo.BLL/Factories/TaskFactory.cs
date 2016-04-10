using System.Collections.Generic;
using System.Linq;
using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class TaskFactory
    {
        public static TaskDTO createReturnDTO(Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                Created = DateTimeConverter.ConvertToUnixTimestamp(task.Created),
                CreatedByUser = (task.CreatedByUser != null) ? UserFactory.createReturnDTO(task.CreatedByUser) : null,
                Tag = (task.Tag != null) ? TagFactory.createReturnDTO(task.Tag) : null
            };
        }

        public static TaskDTO createReturnMinimalDTO(Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                Created = DateTimeConverter.ConvertToUnixTimestamp(task.Created)
            };
        }

        public static List<TaskDTO> createReturnDTOList(List<Task> taskList)
        {
            return taskList.Select(t => createReturnDTO(t)).ToList();
        }

        public static Task createTaskFromDTO(TaskDTO taskDTO)
        {
            return new Task
            {
                Id = taskDTO.Id,
                Description = taskDTO.Description,
                TagId = taskDTO.TagId ?? 0 // TODO proper error handling?
            };
        }
    }
}
