using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.AdminPanel
{
    //this page is for change activity type as ADMIN or USUAL user
    public class ChangeActivityTypeModel : PageModel
    {
        private SuportContext _context;
        public ChangeActivityTypeModel(SuportContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int Id)
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();

            var user = _context.user.SingleOrDefault(s=> s.Id == Id);   

            if(user != null)
            {
                if (user.IsAdmin)
                {
                    user.IsAdmin = false;
                }
                else
                {
                    user.IsAdmin = true;
                }

                _context.SaveChanges();
            }

            return RedirectToPage("UsersManager");
        }
    }
}
