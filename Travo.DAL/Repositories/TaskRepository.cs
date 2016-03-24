using System;
using System.Collections.Generic;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;
using System.Linq;

namespace Travo.DAL.Repositories
{
    public class TaskRepository : EFRepository<Team>, ITaskRepository
    {
        public TaskRepository(TravoDbContext dbContext) : base(dbContext) { }

        public List<Task> GetTasksForTag(int tagId)
        {
            var tasks =
                from t in DbContext.Tasks
                where t.TagId == tagId
                select t;
            return tasks.ToList();
        }
    }
}