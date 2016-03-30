using System;
using System.Collections.Generic;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;
using System.Linq;
using System.Data.Entity;

namespace Travo.DAL.Repositories
{
    public class TaskRepository : EFRepository<Task>, ITaskRepository
    {
        public TaskRepository(TravoDbContext dbContext) : base(dbContext) { }

        public List<Task> GetTasksForTag(int tagId)
        {
            var tasks =
                from tk in DbContext.Tasks
                where tk.TagId == tagId
                select tk;
            return tasks.Include(t => t.Tag).Include(t => t.CreatedByUser).ToList();
        }
    }
}