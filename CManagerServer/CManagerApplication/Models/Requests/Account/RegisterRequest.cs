﻿using System.ComponentModel.DataAnnotations;

namespace CManagerApplication.Models.Requests.Account
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

