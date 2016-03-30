using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITaskRepository : IEFRepository<Domain.Models.Task>
    {
        List<Domain.Models.Task> GetTasksForTag(int tagId);
    }
}
