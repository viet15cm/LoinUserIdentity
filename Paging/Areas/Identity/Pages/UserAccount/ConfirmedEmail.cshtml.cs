using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Paging.Models;
using Paging.Pages.Shared.Components.MessagePage;

namespace Paging.Areas.Identity.Pages.UserAccount
{
    public class ConfirmedEmailModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<ConfirmedEmailModel> _logger;

        public ConfirmedEmailModel(ILogger<ConfirmedEmailModel> logger,
                                    UserManager<AppUser> userManager,
                                    SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public void OnGetSucceeded(bool ConfirmedEmail = false)
        {
            StatusMessage = ConfirmedEmail ? "Thank you for confirming your email " : "Error confirming ";
        }
        public async Task<IActionResult> OnGetAsync([FromQuery]string id , string token, string returUrl)
        {
            ReturnURL = Url.Content("~/");

            //var retunUrlRQ = Url.Page("/UserAccount/ConfirmedEmail", new { area = "Identity", id = id, token = token, retunUrl = returUrl,  Request.Scheme });

            if (id == null && token == null)
            {
                return LocalRedirect(ReturnURL);

            }
            var user = await _userManager.FindByIdAsync(id);
           
            if (user == null)
            {
                return NotFound($"Loi khong co id '{id}'.");
            }
            
            if (user.EmailConfirmed)
            {
                return LocalRedirect(ReturnURL);
            }
            
            if(token != null && id != null)
            {
                token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return RedirectToPage("/UserAccount/ConfirmedEmail", "Succeeded",new { area = "Identity", ConfirmedEmail = true });
    
                }
                return LocalRedirect(ReturnURL);
            }

            StatusMessage = $"Đăng kí thành công mời bạn truy cập email {user.Email} để xác nhận địa chỉ Email";
            return Page();
        }
      
        public string ReturnURL { get; set; }
        [TempData]
        public string StatusMessage { get; set; }


    }
   

}
