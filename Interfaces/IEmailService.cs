using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
        public void SendVerificationCode(string to, string verificationCode);
    }
}