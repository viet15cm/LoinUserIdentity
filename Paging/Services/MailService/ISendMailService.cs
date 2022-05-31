using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.MailService
{
    public interface ISendMailService
    {
        Task SendMail(MailContent content);
        Task<bool> SendMailAsync(MailContent content);
    }
}
