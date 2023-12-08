using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Errors
{
    public class NotFoundRequestException : ApplicationException
    {
        public NotFoundRequestException()
        {
        }

        public NotFoundRequestException(string message) : base(message)
        {
        }

        public NotFoundRequestException(IEnumerable<string> messages) : base(messages)
        {
        }

    }
}