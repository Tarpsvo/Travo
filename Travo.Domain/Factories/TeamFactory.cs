using Travo.Domain.DTO;
using Travo.Domain.Models;

namespace Travo.Domain.Factories
{
    class TeamFactory
    {
        public TeamGetDTO createBasicDTO(Team Team)
        {
            return new TeamGetDTO
            {
                Id = Team.Id,
                Name = Team.Name,
                Created = DateTimeConverter.ConvertToUnixTimestamp(Team.Created),
                Description = Team.Description
            };
        }
    }
}
