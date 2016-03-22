using Travo.BLL.DTO;
using Travo.Domain.Models;

namespace BLL.Factories
{
    class UserFactory
    {
        public UserDTO createBasicDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };
        }
    }
}
