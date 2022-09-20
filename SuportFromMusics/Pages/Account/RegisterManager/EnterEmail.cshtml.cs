using UserServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using Suport.Data.Repository;
using UserServices.Services;

namespace SuportFromMusics.Pages.Account.RegisterManager
{
    public class EnterEmailModel : PageModel
    {
        private ISendEmail _sendPasswordWithEmail;
        private SuportContext _context;
        private IAddUser _adduser;

        public EnterEmailModel(ISendEmail sendPasswordWithEmail, SuportContext context, IAddUser addUser)
        {
            _context = context;
            _sendPasswordWithEmail = sendPasswordWithEmail;
            _adduser = addUser;
        }

        [BindProperty]
        public AddUserViewModel addUservm { get; set; }

        public int RandomNumber { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(addUservm.Email))
            {
                return Page();
            }

            var user = _context.user.SingleOrDefault(u => u.Email == addUservm.Email);

            if (user != null)
            {
                if (!user.IsFinishedSubName)
                    return RedirectToPage("SubmitName", new { email = user.Email });

                else
                {
                    ViewData["Error"] = "این ایمیل از قبل ثبت نام کرده است";
                    return Page();
                }

            }
            
            string email_securit = MakeSecuritEmail(addUservm.Email);

            return RedirectToPage("CheckPassword", new { emailAddres = email_securit });

        }


        //Method for make securit email for return to the checkpassword page
        public string MakeSecuritEmail(string email)
        {
            string s_email = "";
            for (int i = 0; i < email.Length; i++)
            {
                s_email += (char)((addUservm.Email[i]) + (addUservm.Email.Length + i));
            }

            return s_email;
        }
    }
}
