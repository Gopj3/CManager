using System;
namespace CManagerApplication.Models.Results.Account
{
    public class AuthResult
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}

