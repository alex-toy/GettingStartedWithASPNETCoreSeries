using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
