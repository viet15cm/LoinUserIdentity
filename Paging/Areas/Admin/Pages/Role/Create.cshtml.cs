using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paging.DbContextLayer;

namespace Paging.Areas.Admin.Pages.Role
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, UserDbContext userDbContext) : base(roleManager, userDbContext)
        {
        }
        
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name="Tên role")]
            [Required(ErrorMessage ="Bạn phải nhập {0}")]
            [StringLength(256, MinimumLength = 3 , ErrorMessage = "{0} phải dài từ {2} đến {1}")]
            public string Name { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult>  OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var role = new IdentityRole(Input.Name);
            var result =  await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa tạo thành công roler {Input.Name}";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return Page();
        }
    }
}
