using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paging.Models;

namespace Paging.Areas.Admin.Pages.User
{
    public class SetPasswordModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SetPasswordModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public AppUser user { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="Phải nhập {0}")]
            [StringLength(100, ErrorMessage = "{0} tối đa từ {2} kí tự đến {1} kí tự ", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu mới")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Nhập lại mật khẩu mới ")]
            [Compare("NewPassword", ErrorMessage = "Không trùng nhau")]
            public string ConfirmPassword { get; set; }
        }

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

            await  _userManager.RemovePasswordAsync(user);

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
