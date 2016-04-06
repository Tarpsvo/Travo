﻿using Travo.BLL.DTO;
using Travo.BLL.Helpers;
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

        public static UserDTO createDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Created = DateTimeConverter.ConvertToUnixTimestamp(user.Created),
                DisplayName = user.DisplayName
            };
        }
    }
}
