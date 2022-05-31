using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paging.Models;

namespace Paging.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public IndexModel (UserManager<AppUser> userManager)
        {
            _userManager = userManager; 
        }

        public List<AppUser> users;
        public async Task OnGet()
        {
            users = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();
        }

        public void OnePostAsync()
        {

        }
    }
}
