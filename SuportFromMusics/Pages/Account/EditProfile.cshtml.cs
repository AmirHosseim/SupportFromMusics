using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using System.Security.Claims;
using UserServices;
using UserServices.ViewModels;

namespace SuportFromMusics.Pages.Account
{
    [Authorize]
    public class EditProfileModel : PageModel
    {
        private SuportContext _context;
        public EditProfileModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddUserViewModel editUser { get; set; }

        [BindProperty]
        public long userId { get; set; }
        public IActionResult OnGet()
        {
            userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _context.user.SingleOrDefault(u => u.Id == userId);

            editUser = new AddUserViewModel()
            {
                Password = user.Password,
                UserName = user.UserName,
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            var user = _context.user.SingleOrDefault(u => u.Id == userId);

            user.UserName = editUser.UserName;
            user.Password = editUser.Password;

            _context.SaveChanges();

            return RedirectToPage("MyProfile");
        }
    }
}
