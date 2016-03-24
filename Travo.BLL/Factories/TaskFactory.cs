using System.Collections.Generic;
using System.Linq;
using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class TaskFactory
    {
        public static TaskDTO createBasicDTO(Task task)
        {
            return new TaskDTO
            {
                Created = DateTimeConverter.ConvertToUnixTimestamp(task.Created),
                Description = task.Description,
                Id = task.Id
            };
        }

        public static List<TaskDTO> createBasicDTOList(List<Task> taskList)
        {
            return taskList.Select(t => createBasicDTO(t)).ToList();
        }
    }
}
