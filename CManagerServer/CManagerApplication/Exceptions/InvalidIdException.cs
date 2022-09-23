using System;

namespace CManagerApplication.Exceptions
{
    public class InvalidIdException: Exception
    {
        public InvalidIdException(string message): base(message)
        {
            
        }
    }
}