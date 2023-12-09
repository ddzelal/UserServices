using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Interfaces
{
    public interface ICodeGenerator
    {
        string GenerateVerificationCode();
    }
}