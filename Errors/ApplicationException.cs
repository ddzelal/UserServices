using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Errors
{
    public class ApplicationException : Exception
    {
        private static readonly string ErrorSeparator = ";ErrorSeparator;";
        public IEnumerable<string> Messages => new List<string>(base.Message.Split(new[] { ErrorSeparator }, StringSplitOptions.RemoveEmptyEntries));
        public ApplicationException() : base() { }
        public ApplicationException(string message) : base(message) { }
        public ApplicationException(IEnumerable<string> messages) : base(string.Join(ErrorSeparator, messages)) { }
    }
}