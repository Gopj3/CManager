using System;

namespace CManagerApplication.Models.DTO.Users
{
    public class BasicUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}