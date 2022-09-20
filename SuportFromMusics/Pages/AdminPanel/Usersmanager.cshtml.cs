using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using System.Security.Claims;
using UserServices.Repository;
using UserServices.ViewModels;

namespace SuportFromMusics.Pages.AdminPanel
{
    [Authorize]
    public class UsersmanagerModel : PageModel
    {
        private SuportContext _context;
        private IGetUsers _getUsers;
        public UsersmanagerModel(SuportContext context,IGetUsers getUsers)
        {
            _context = context;
            _getUsers = getUsers;
        }

        public ShowUsers showUsers { get; set; }
        public IActionResult OnGet(int PageId = 1)
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();
            
            var users = _context.user.ToList();

            showUsers = _getUsers.getUsers(PageId, users);

            return Page();
        }
    }
}
