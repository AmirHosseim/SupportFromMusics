using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    [Authorize]
    public class LikeModel : PageModel
    {
        private SuportContext _context;
        public LikeModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long SingDetailId)
        {
            var sing = _context.singDetail.Include(s=> s.theSingsLike).SingleOrDefault(s => s.Id == SingDetailId);

            if(sing == null)
            {
                return NotFound();
            }

            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var Like = _context.Like.SingleOrDefault(l => l.UserId == UserId && l.SingDetailId == sing.Id);

            if(Like != null)
            {
                _context.Like.Remove(Like);
            }
            else
            {
                Like = new theSingsLike()
                {
                    SingDetailId = sing.Id,
                    UserId = UserId,
                    SingDetail = sing,
                };

                _context.Like.Add(Like);
            }

            _context.SaveChanges();


            return RedirectToPage("SingDetail", new { Id = sing.Id });
        }
    }
}
