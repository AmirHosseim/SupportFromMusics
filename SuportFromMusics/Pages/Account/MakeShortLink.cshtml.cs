using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Account
{
    [Authorize]
    public class MakeShortLinkModel : PageModel
    {
        private SuportContext _context;
        public MakeShortLinkModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long SingerId)
        {
            var singer = _context.singer.SingleOrDefault(s => s.Id == SingerId);

            if (singer == null)
            {
                return NotFound();
            }

            string Key = Guid.NewGuid().ToString().Replace("_", " ").Substring(0, 4);

            while (_context.singer.Any(s => s.ShortLink == Key))
            {
                Key = Guid.NewGuid().ToString().Replace("_", " ").Substring(0, 4);
            }

            singer.ShortLink = Key;
            _context.SaveChanges();

            return RedirectToPage("MyProfile");
        }
    }
}
