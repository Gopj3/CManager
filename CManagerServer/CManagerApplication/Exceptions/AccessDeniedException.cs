using System;
namespace CManagerApplication.Exceptions
{
    public class AccessDeniedException: Exception
    {
        public AccessDeniedException(string message): base(message)
        {
        }
    }
}

