using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Api.Helpers
{
    public class EmailHelper
    {
        private readonly IOptionsMonitor<MailSettings> _mailSettings;

        public EmailHelper(IOptionsMonitor<MailSettings> options)
        {
            _mailSettings = options;
        }

        public async Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellation = default)
        {
            // التحقق من القيم المدخلة
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentException("Recipient email cannot be empty.", nameof(to));
            if (string.IsNullOrWhiteSpace(subject)) throw new ArgumentException("Email subject cannot be empty.", nameof(subject));
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentException("Email body cannot be empty.", nameof(body));

            var settings = _mailSettings.CurrentValue;

            if (string.IsNullOrWhiteSpace(settings.FromEmail))
                throw new InvalidOperationException("Sender email address is not configured.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(settings.DisplayedName ?? "No Name", settings.FromEmail));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(settings.SmtpServer, settings.Port, SecureSocketOptions.StartTls, cancellation);
                    await client.AuthenticateAsync(settings.FromEmail, settings.Password, cancellation);
                    await client.SendAsync(message, cancellation);
                    await client.DisconnectAsync(true, cancellation);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while sending the email.", ex);
            }
        }
    }
}
