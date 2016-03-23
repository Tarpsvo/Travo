using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class TeamFactory
    {
        public static TeamDTO createBasicDTO(Team Team)
        {
            return new TeamDTO
            {
                Id = Team.Id,
                Name = Team.Name,
                Created = DateTimeConverter.ConvertToUnixTimestamp(Team.Created),
                Description = Team.Description
            };
        }
    }
}
