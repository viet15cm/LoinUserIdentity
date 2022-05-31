using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Paging.Pages
{
    public class BindingModel : PageModel
    {
      
        [BindProperty]
        public string HomeName { get; set; }
        public void OnGet(int? id , string name)
        {
            var data2 = Request.RouteValues["id"];
            Console.WriteLine(data2.ToString());
            Console.WriteLine(HomeName);

        }

        public void OnPost()
        {
            Console.WriteLine(HomeName);
        }
    }
}
