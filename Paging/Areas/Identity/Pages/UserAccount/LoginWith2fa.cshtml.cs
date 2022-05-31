using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Paging.Models;
using Paging.Services.MailService;

namespace Paging.Areas.Identity.Pages.UserAccount
{
    public class LoginWith2faModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ISendMailService _sendMail;
        private readonly ILogger<LoginWith2faModel> _logger;

        public LoginWith2faModel(SignInManager<AppUser> signInManager, ILogger<LoginWith2faModel> logger, UserManager<AppUser> userManager, ISendMailService sendMail)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _sendMail = sendMail;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public string StatusMessage { get; set; }
        
        public class InputModel
        {
            [Required]
            [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Authenticator code")]
            public string TwoFactorCode { get; set; }

            [Display(Name = "Remember this machine")]
            public bool RememberMachine { get; set; }           
        }
        public async Task<IActionResult> OnGetAsync(bool rememberMe = false, string returnUrl = null, bool resetCode = false)
        {
            // Trả về đối tương aapUser đang đăng nhập hiện tại.
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Không thể tải người dùng xác thực hai yếu tố.");
                
            }
            // Tạo Key gồm dãy số
            var key = await _userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(key) || resetCode)
            {
                //reset lại key để tạo code mới xác thực
                await _userManager.ResetAuthenticatorKeyAsync(user);
                // Tạo Key gồm dãy số ngẫu nhiên  
                //key = await _userManager.GetAuthenticatorKeyAsync(user);
                //Mã Hóa key
                //key = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(key));
                //TẠO dãy code gồm 7 chữ số ngẫu nhiên              
                var code = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
                // Tạo Key gồm dãy số ngẫu nhiên
                //key = await _userManager.GetAuthenticatorKeyAsync(user);
                //key = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(key));
                var mailContent = new MailContent()
                {
                    To = user.Email,
                    Subject = "Xác nhận địa chỉ email",
                    //chuổi 7 số được gửi qua emil
                    Body = $"Hãy nhập mã {code} Để Đăng Nhập"    
                };
                var isSendMail = await _sendMail.SendMailAsync(mailContent);

                StatusMessage = isSendMail ? "Gửi email thành công" : "Error Gửi email thất bại";
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(bool rememberMe = false, string returnUrl = null)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            //var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            //key = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(key));
            if (user == null)
            {
                throw new InvalidOperationException($"Không thể tải người dùng xác thực hai yếu tố..");
            }
            var authenticatorCode = Input.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            //var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, Input.RememberMachine);
            var result = await _signInManager.TwoFactorSignInAsync("Email", authenticatorCode, rememberMe, Input.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Người dùng có ID '{0}' đã đăng nhập bằng 2fa. ", user.Id);        
                return LocalRedirect(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning($"Người dùng có tài khoản ID '{0}' đã bị khóa.", user.Id);
                return RedirectToPage("./Lockout");
            }
            else
            {
                _logger.LogWarning("Đã nhập mã xác thực không hợp lệ cho người dùng có ID '{UserId}'.", user.Id);
                ModelState.AddModelError(string.Empty, "Mã xác thực không hợp lệ.");
                return Page();
            }
        }
    }
}
