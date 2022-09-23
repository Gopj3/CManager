using System.Collections.Generic;
using System.Linq;
using CManagerApplication.Models.DTO.Users;
using CManagerData.Entities;

namespace CManagerApplication.Models.DTO.Mappers
{
    public static class UsersMapper
    {
        public static BasicUserDto ToDto(this User user)
        {
            return new BasicUserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public static List<BasicUserDto> ToDtos(this List<User> users)
        {
            var listDtos = new List<BasicUserDto>();
            
            if (users == null || users.Count == 0)
            {
                return listDtos;
            }

            return users.Select(el => el.ToDto()).ToList();
        }
    }
}