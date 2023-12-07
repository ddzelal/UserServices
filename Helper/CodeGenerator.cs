using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Interfaces;

namespace UserRepository.Helper
{
    public class CodeGenerator : ICodeGenerator
    {
        public int GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}