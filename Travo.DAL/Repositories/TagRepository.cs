using System;
using System.Collections.Generic;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;
using System.Linq;

namespace Travo.DAL.Repositories
{
    public class TagRepository : EFRepository<Team>, ITagRepository
    {
        public TagRepository(TravoDbContext dbContext) : base(dbContext) { }

        public List<Tag> GetTagsForBoard(int boardId)
        {
            var tags =
                from t in DbContext.Tags
                where t.BoardId == boardId
                select t;
            return tags.ToList();
        }
    }
}