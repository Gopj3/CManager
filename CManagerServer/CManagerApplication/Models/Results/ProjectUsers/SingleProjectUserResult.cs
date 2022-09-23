using CManagerApplication.Models.DTO.Users;
using CManagerData.Enums.Projects;

namespace CManagerApplication.Models.Results.ProjectUsers
{
    public class SingleProjectUserResult
    {
        public BasicUserDto User { get; set; }
        public string Role { get; set; }
    }
}