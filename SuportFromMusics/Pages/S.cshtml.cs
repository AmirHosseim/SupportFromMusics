using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages
{
    public class S : PageModel
    {
        private SuportContext _context;
        public S(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string Key)
        {
            var singer = _context.singer.SingleOrDefault(s=> s.ShortLink == Key);

            if(singer == null)
            {
                return NotFound();
            }

            return RedirectToPage("/sing/singerAccountDetail",new {Id = singer.Id});
        }
    }
}
