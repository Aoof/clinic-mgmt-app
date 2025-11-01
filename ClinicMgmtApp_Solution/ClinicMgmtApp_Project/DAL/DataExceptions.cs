using System;
namespace ClinicMgmtApp_Project.DAL
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found in the database.") { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized access.") { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
    }

    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password.") { }
        public InvalidCredentialsException(string message) : base(message) { }
        public InvalidCredentialsException(string message, Exception inner) : base(message, inner) { }
    }

    // SQL related exceptions
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException() : base("Failed to connect to the database.") { }
        public DatabaseConnectionException(string message) : base(message) { }
        public DatabaseConnectionException(string message, Exception inner) : base(message, inner) { }
    }

    public class UniqueConstraintViolationException : Exception
    {
        public UniqueConstraintViolationException() : base("Unique constraint violation occurred.") { }
        public UniqueConstraintViolationException(string message) : base(message) { }
        public UniqueConstraintViolationException(string message, Exception inner) : base(message, inner) { }
    }

    public class ForeignKeyConstraintViolationException : Exception
    {
        public ForeignKeyConstraintViolationException() : base("Foreign key constraint violation occurred.") { }
        public ForeignKeyConstraintViolationException(string message) : base(message) { }
        public ForeignKeyConstraintViolationException(string message, Exception inner) : base(message, inner) { }
    }

    public class DataRetrievalException : Exception
    {
        public DataRetrievalException() : base("Error occurred while retrieving data from the database.") { }
        public DataRetrievalException(string message) : base(message) { }
        public DataRetrievalException(string message, Exception inner) : base(message, inner) { }
    }
}
