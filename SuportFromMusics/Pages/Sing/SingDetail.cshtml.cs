using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices;
using System.Collections.Generic;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    public class SingDetailModel : PageModel
    {

        private SuportContext _context;
        public SingDetailModel(SuportContext context)
        {
            _context = context;
        }

        public SingDetail sing { get; set; }

        public IEnumerable<SongVersies> SongVersies { get; set; }

        //this praperty is for show the others sings of singer
        public IEnumerable<SingDetail> Singer_Other_Sings { get; set; }
        public SuportForm SuportForm { get; set; }
        public theSingsLike Like { get; set; }
        public SaveSing SingSave { get; set; }
        public IActionResult OnGet(int Id)
        {

#pragma warning disable CS8601 // Possible null reference assignment.
            sing = _context.singDetail.Include(x => x.singer)
                .Include(s => s.singType).Include(l=> l.theSingsLike)
                    .SingleOrDefault(s => s.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.

            if (sing == null)
            {
                return NotFound();
            }

            Singer_Other_Sings = _context.singDetail.Where(s => s.SingerId == sing.SingerId && !_context.singDetail.Contains(sing));

            Singer_Other_Sings.Skip(Singer_Other_Sings.Count() - 4).Take(4);

            SongVersies = _context.SongVersies.Where(v => v.SingDetailId == sing.Id);

            SuportForm = _context.SuportForm.SingleOrDefault(s => s.SingDetailId == sing.Id);

            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                Like = _context.Like.SingleOrDefault(l => l.SingDetailId == sing.Id && l.UserId == userid);

                SingSave = _context.SaveSing.SingleOrDefault(s => s.UserId == userid && s.SingDetailId == sing.Id);
            }

            return Page();
        }
    }
}
