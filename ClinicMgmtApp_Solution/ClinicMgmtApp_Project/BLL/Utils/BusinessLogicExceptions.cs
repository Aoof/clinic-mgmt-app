using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMgmtApp_Project.BLL
{
    public class UserNotAuthenticated : Exception
    {
        public UserNotAuthenticated() : base("User is not authenticated.") { }
        public UserNotAuthenticated(string message) : base(message) { }
        public UserNotAuthenticated(string message, Exception inner) : base(message, inner) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException() : base("Data validation failed.") { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized access.") { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
    }
}
