using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITagRepository : IEFRepository<Tag>
    {
        List<Tag> GetTagsForBoard(int boardId);
    }
}
