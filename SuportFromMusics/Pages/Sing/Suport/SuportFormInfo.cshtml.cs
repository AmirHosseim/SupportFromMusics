using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Sing.Suport
{
    public class SuportFormInfoModel : PageModel
    {
        private SuportContext _context;

        public SuportFormInfoModel(SuportContext context)
        {
            _context = context;
        }

        public SuportForm SuportForm { get; set; }
        public void OnGet(long SuportId)
        {
            SuportForm = _context.SuportForm.Include(s=> s.SuportedUsers).ThenInclude(u=> u.User).SingleOrDefault(s => s.Id == SuportId);

            if(SuportForm.SuportedUsers.Count() == 0)
            {
                ViewData["ErrorMessage"] = "هیچ کاربری از این ترک همایت نکرده است";
            }

        }
    }
}
