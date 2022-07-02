using System;
using System.Collections.Generic;

namespace CManagerApplication.Models.Results.Account
{
    public class RegistrationResult
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

