using Travo.BLL.DTO;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class UserFactory
    {
        public static UserDTO createBasicDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };
        }
    }
}
