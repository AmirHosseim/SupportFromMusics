using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using UserServices;
using UserServices.Services;

namespace SuportFromMusics.Pages.Account.RegisterManager
{
    public class CheckPasswordModel : PageModel
    {
        private ISendEmail _sendPassword;
        private SuportContext _context;
        public CheckPasswordModel(ISendEmail sendPassword,SuportContext context)
        {
            _sendPassword = sendPassword;
            _context = context;
        }

        [BindProperty]
        public int RandomPass { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [HttpGet]
        public IActionResult OnGet(string emailAddres)
        {

            for (int i = 0; i < emailAddres.Length; i++)
            {
                Email += (char)((emailAddres[i]) - (emailAddres.Length + i));
            }

            int Randnum = new Random().Next(1000, 9999);
            string emailMessage = "سلام به شما کاربر " +
                Email + " " +
                    "از ثبت نام شما در وب سایت ما خوشنودیم " +
                        "رمز چهار رقمی " + Randnum;
            try
            {
                _sendPassword.sendEmail(Email, emailMessage);
                RandomPass = Randnum;
                ViewData["MessageForClient"] = "رمز عبور به ایمیل شما ارسال شد لطفا آن را وارد کنید";
            }
            catch
            {
                ViewData["MessageForClient"] = "مشکلی در ارسال ایمیل به وجود آمد. از وصل بودن اینترنت خود اطمینان حاصل فرمایید";
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var user = new User()
            {
                Email = Email,
                //the allowNull of Praperties are false in dataBase so set a Deafult Value
                Password = "0",
                UserName = "0",
            };

            _context.user.Add(user);
            _context.SaveChanges();

            return RedirectToPage("SubmitName", new { email = user.Email });
        }
    }
}
