using System.Collections.Generic;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITaskRepository : IEFRepository<Task>
    {
        List<Task> GetTasksForTag(int tagId);
    }
}
