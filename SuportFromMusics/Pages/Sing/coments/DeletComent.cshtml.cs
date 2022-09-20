using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.coments
{
    public class DeletComentModel : PageModel
    {

        private SuportContext _context;
        public DeletComentModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long Id)
        {
            var coment = _context.Coment.SingleOrDefault(c => c.Id == Id);
            if (coment == null)
            {
                return NotFound();
            }

            //coment id for Redirect to page
            long singDetailId = coment.SingDetailId;

            _context.Coment.Remove(coment);
            _context.SaveChanges();

            return RedirectToPage("Allcoments", new { SingDetailId = singDetailId });
        }
    }
}
