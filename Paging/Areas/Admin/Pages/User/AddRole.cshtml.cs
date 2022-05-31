using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paging.Models;

namespace Paging.Areas.Admin.Pages.User
{
    public class AddRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public  AppUser user { get; set; }

        [BindProperty]
        [Display(Name = "Rolenames")]
        public string [] RoleNames { get; set; }

        public SelectList select { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Không tìm thấy id");
            }
            user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Không tìm thấy user có id {id}");
            }

            RoleNames= (await _userManager.GetRolesAsync(user)).ToArray<string>();

            List<string>roles = await _roleManager.Roles.Select(r=> r.Name).ToListAsync();

            select = new SelectList(roles);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Không tìm thấy id");
            }

            user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                return NotFound($"Không tìm thấy user");
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            var oldRoleName = (await _userManager.GetRolesAsync(user)).ToArray<string>();

            var deleteRolename = oldRoleName.Where(r => !RoleNames.Contains(r));


            await _userManager.RemovePasswordAsync(user);

            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = $"Bạn vừa đặt mật khẩu cho user {user.UserName}";

            return RedirectToPage();
        }
    }
}
