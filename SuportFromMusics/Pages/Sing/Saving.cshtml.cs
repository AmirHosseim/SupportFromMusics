using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using System.Security.Claims;
using SingServices;

namespace SuportFromMusics.Pages.Sing
{
    [Authorize]
    public class SavingModel : PageModel
    {
        private SuportContext _context;   
        public SavingModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long SingDetailId)
        {
            var Sing = _context.singDetail.SingleOrDefault(s => s.Id == SingDetailId);

            if(Sing == null)
            {
                return NotFound();
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var SaveSing = _context.SaveSing.SingleOrDefault(s => s.SingDetailId == Sing.Id && s.UserId == userId);
            
            if(SaveSing == null)
            {
                SaveSing = new SaveSing() { 
                    UserId = userId,
                    SingDetailId = Sing.Id,
                    SingDetail = Sing,
                };
                _context.SaveSing.Add(SaveSing);
                
            }
            else
            {
                _context.SaveSing.Remove(SaveSing);
            }

            _context.SaveChanges();

            return RedirectToPage("SingDetail", new { Id = Sing.Id });
        }
    }
}
