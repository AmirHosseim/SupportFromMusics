using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using UserServices.Services;

namespace SuportFromMusics.Pages.AdminPanel
{
    public class SendEmailForUsersModel : PageModel
    {
        private ISendEmail _sendEmail;
        public SendEmailForUsersModel(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        [BindProperty]
        public SendEmailViewModel sendEmail { get; set; }
        public IActionResult OnGet()
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (sendEmail.Message == null || sendEmail.Email == null)
            {
                ViewData["ErrorMessage"] = "لطفا تمام المان هارا پر کنید";
                return OnGet();
            }

            try
            {
                _sendEmail.sendEmail(sendEmail.Email, sendEmail.Message,"ایمیل برای شما");
            }
            catch
            {
                ViewData["ErrorMessage"] = "مشکلی در ارسال ایمیل به وجود آمد";
            }
            return OnGet();
        }
    }

    public class SendEmailViewModel
    {
        public string Message { get; set; }

        public string Email { get; set; }
    }

}
