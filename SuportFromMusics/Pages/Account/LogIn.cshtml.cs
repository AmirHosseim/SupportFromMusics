using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Suport.Data.Repository;
using System.Security.Claims;
using SuportFromMusics.Data;
using UserServices.ViewModels;

namespace SuportFromMusics.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SuportContext _context;
        public LoginModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public logInViewModel loginvm { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.user.FirstOrDefault(u=> u.Email == loginvm.Email && u.Password == loginvm.Password);

            if(user == null)
            {
                ViewData["ErrorMessage"] = "حسابی با این مشخصات یافت نشد";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin",user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = loginvm.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
    }
}
