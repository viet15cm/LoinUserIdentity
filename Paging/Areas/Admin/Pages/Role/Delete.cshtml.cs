using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paging.DbContextLayer;

namespace Paging.Areas.Admin.Pages.Role
{
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, UserDbContext userDbContext) : base(roleManager, userDbContext)
        {
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IdentityRole role { get; set; }
        public class InputModel
        {
            public string Name { get; set; }
        }
        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound($"Không tìm thấy id");
            }

            role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                Input = new InputModel()
                {
                    Name = role.Name
                };

                return Page();
            }

            return NotFound("Không tìm thấy role");

        }

        public async Task<IActionResult> OnPost(string id)
        {
            if (id == null)
            {
                return NotFound("Không tìm thấy id");
            }

            role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound("Không tìm thấy role");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                StatusMessage = $"Xóa Role {role.Name} thành công !";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error => {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }

            return Page();
        }

    }
}
