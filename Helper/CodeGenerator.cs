using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Interfaces;

namespace UserRepository.Helper
{
    public class CodeGenerator : ICodeGenerator
    {
        public string GenerateResetPasswordCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}