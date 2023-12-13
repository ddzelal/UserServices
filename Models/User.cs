using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public string? VerificationCode { get; set; }
        public string? ResetPasswordCode { get; set; }
        public Role Role { get; set; } = Role.BasicUser;

    }
}