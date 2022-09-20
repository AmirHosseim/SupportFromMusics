using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.AdminPanel
{
    public class SingersManagerModel : PageModel
    {
        private SuportContext _context;
        private IGetSingers _getSingers;
        public SingersManagerModel(SuportContext context,IGetSingers getSingers)
        {
            _context = context;
            _getSingers = getSingers;
        }

        public ShowSingersViewModel showSingers { get; set; }
        public IActionResult OnGet(int PageId)
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();

            showSingers = _getSingers.getSingers(PageId, _context.singer.Include(s=> s.Followers).ToList());

            return Page();
        }
    }
}
