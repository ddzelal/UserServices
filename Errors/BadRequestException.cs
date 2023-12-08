using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Errors
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(IEnumerable<string> messages) : base(messages)
        {
        }

    }
}