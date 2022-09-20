using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Sing
{
    public class DeletVersModel : PageModel
    {
        private SuportContext _context;

        public DeletVersModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int VersId)
        {
            var vers = _context.SongVersies.SingleOrDefault(v => v.Id == VersId);
            if(vers == null)
            {
                return NotFound();
            }
            //get Sing Id for Redirect to page
            long SingId = vers.SingDetailId;
            _context.SongVersies.Remove(vers);
            _context.SaveChanges();

            return RedirectToPage("AddVersText", new { SingId = SingId });
        }
    }
}
