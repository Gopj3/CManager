using System;
using System.ComponentModel.DataAnnotations;

namespace CManagerApplication.Models.Requests.Account
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

