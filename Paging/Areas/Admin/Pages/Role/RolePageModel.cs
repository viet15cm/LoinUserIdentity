using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paging.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UserDbContext _userDbContext;
        [TempData]
        public string StatusMessage { get; set; }
        public RolePageModel(RoleManager<IdentityRole> roleManager , UserDbContext userDbContext)
        {
            _roleManager = roleManager;
            _userDbContext = userDbContext;
        }
    }
}
