using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Paging.Models;
using Paging.Services.MailService;

namespace Paging.Areas.Identity.Pages.UserAccount
{
    public class RegisterModel : PageModel
    {
        private readonly ISendMailService _sendMail;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;


        public RegisterModel(
            ISendMailService sendMail,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger
            )

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sendMail = sendMail;
            _logger = logger;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public string StatusMessage { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var appUser = new AppUser() { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(appUser, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Them thanh cong");

                    if (_signInManager.Options.SignIn.RequireConfirmedEmail)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                        token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                        var callbackUrl = Url.Page(
                            "/UserAccount/ConfirmedEmail",
                            pageHandler: null,
                            values: new { area = "Identity", Id = appUser.Id, token = token, returnUrl = returnUrl },
                            protocol: Request.Scheme);
                        var mailContent = new MailContent()
                        {
                            To = Input.Email,
                            Subject = "Xác nhận địa chỉ email",
                            Body = $"Hãy xác nhận địa chỉ email bằng cách <a href={callbackUrl}>Bấm vào đây</a>."
                            //chuổi 5 số được gửi qua emil
                            //Body = $"Hãy nhập mã {code} đểa xác nhận địa chỉ email"
                        };
                        var isSendEmail = await _sendMail.SendMailAsync(mailContent);

                        StatusMessage = isSendEmail? "Gửi email thành công" : "Error Gửi Email thất bại";

                        if (!isSendEmail)
                        {
                            return Page();
                        }

                        _logger.LogInformation("chuyen trang");
                        return RedirectToPage("/UserAccount/ConfirmedEmail", new { area = "Identity", id = appUser.Id });
                    }
                    //Xóa sạch dữ liệu cookie của User
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return LocalRedirect(returnUrl);

                }

                ModelState.AddModelError(string.Empty, "Lỗi!!!!!!");
                return Page();
            }
            ModelState.AddModelError(string.Empty, "Loi he thong");
            return Page();
        }

        public class InputModel
            {
                [Required]
                [EmailAddress]
                [Display(Name = "Địa chỉ Email")]
                public string Email { get; set; }

                [Required]
                [StringLength(100, ErrorMessage = "{0} dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
                [DataType(DataType.Password)]
                [Display(Name = "Mật khẩu")]
                public string Password { get; set; }

                [DataType(DataType.Password)]
                [Display(Name = "Nhập lại mật khẩu")]
                [Compare("Password", ErrorMessage = "Mật khẩu không giống nhau")]
                public string ConfirmPassword { get; set; }


            }
    }
}
