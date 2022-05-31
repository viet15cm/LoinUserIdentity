using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.MailService
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSetting mailSetting;
        private readonly ILogger<SendMailService> logger;
        public SendMailService(IOptions<MailSetting> options, ILogger<SendMailService> logger)
        {
            mailSetting = options.Value;
            this.logger = logger;
        }

        public Task SendMail(MailContent content)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendMailAsync(MailContent content)
        {

            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSetting.Name, mailSetting.Mail);
            email.From.Add(new MailboxAddress(mailSetting.Name, mailSetting.Mail));
            email.To.Add(MailboxAddress.Parse(content.To));
            email.Subject = content.Subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = content.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(mailSetting.Host, mailSetting.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSetting.Mail, mailSetting.Password);
                await smtp.SendAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                if (!Directory.Exists("~/mailssave"))
                {
                    Directory.CreateDirectory("mailssave");
                }
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + content.To);

            return false;
        }
    }
}
