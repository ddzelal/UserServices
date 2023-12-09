using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using UserRepository.Helper;
using UserRepository.Interfaces;

namespace UserRepository.Services
{
    public class EmailService : IEmailService
    {

        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _emailSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.SmtpUser, _emailSettings.SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendResetCode(string to, string resetPasswordCode)
        {
            string subject = "Reset password Code";
            string htmlBody = $"Your  code is: {resetPasswordCode}";
            Send(to, subject, htmlBody);
        }

        public void SendVerificationCode(string to, string verificationCode)
        {
            string subject = "Verification Code";
            string htmlBody = $"Your verification code is: {verificationCode}";
            Send(to, subject, htmlBody);
        }
    }
}