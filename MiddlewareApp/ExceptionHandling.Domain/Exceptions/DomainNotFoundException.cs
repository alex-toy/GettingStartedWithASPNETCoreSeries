using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Domain.Exceptions
{
    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {
        }
    }
}
