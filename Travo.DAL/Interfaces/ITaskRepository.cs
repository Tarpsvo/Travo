using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITaskRepository
    {
        List<Domain.Models.Task> GetTasksForTag(int tagId);
    }
}
