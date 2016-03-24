using System.Collections.Generic;

namespace Travo.BLL.DTO
{
    public class TagWithTasksDTO
    {
        public TagDTO Tag { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}
