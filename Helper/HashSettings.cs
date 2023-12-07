using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Helper
{
    public class HashSettings
    {
        public const string SectionName = "HashSettings";

        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
        public char Separator { get; set; }
    }
}