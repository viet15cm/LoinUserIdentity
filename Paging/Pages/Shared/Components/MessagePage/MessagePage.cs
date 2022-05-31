using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Pages.Shared.Components.MessagePage
{
    public class MessagePage : ViewComponent
    {
        public const string NameComponent = "MessagePage";

        public class Message
        {
            public string Title { get; set; }
            public string Htmlcontent { get; set; }

            public string ReturnUrl { get; set; }

            public int Secondwait { get; set; }
        }

        public  IViewComponentResult Invoke(Message message)
        {
            this.HttpContext.Response.Headers.Add("REFRESH", $"{message.Secondwait}; URL={message.ReturnUrl}");
            return View(message);
        }
    }
}
