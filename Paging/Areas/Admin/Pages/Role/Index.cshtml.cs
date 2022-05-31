using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paging.DbContextLayer;

namespace Paging.Areas.Admin.Pages.Role
{
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, UserDbContext userDbContext) : base(roleManager, userDbContext)
        {
        }
        [BindProperty]
        public ICollection<IdentityRole> roles { get; set; }
        public async Task OnGet()
        {
            roles = await _roleManager.Roles.ToListAsync();
        }
        public void  OnPost()
        {
             RedirectToPage();
        }
    }
}
