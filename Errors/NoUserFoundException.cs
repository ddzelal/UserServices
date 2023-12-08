using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Errors
{
    public class NoUserFoundException : ApplicationException
    {
        public NoUserFoundException()
        {
        }

        public NoUserFoundException(string message) : base(message)
        {
        }

        public NoUserFoundException(IEnumerable<string> messages) : base(messages)
        {
        }

    }
}