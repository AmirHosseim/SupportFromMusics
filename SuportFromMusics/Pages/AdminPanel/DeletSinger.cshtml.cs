using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.AdminPanel
{
    public class DeletSingerModel : PageModel
    {
        private SuportContext _context;
        public DeletSingerModel(SuportContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(long Id)
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();

            var singer = _context.singer.Include(s=> s.singDetails).SingleOrDefault(s => s.Id == Id);

            if (singer != null) {
                _context.singDetail.RemoveRange(singer.singDetails);
                _context.singer.Remove(singer);
            }

            return RedirectToPage("SingerManager");
        }
    }
}
