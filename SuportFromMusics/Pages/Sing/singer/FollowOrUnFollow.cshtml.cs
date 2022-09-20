using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SingServices;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.singer
{
    [Authorize]
    public class FollowOrUnFollowModel : PageModel
    {
        private SuportContext _context;

        public FollowOrUnFollowModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long SingerId)
        {
            var Singer = _context.singer.SingleOrDefault(s => s.Id == SingerId);

            if(Singer == null)
            {
                return NotFound();
            }

            long Userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

            FollowSinger follow = _context.FollowSingers.SingleOrDefault(f => f.UserId == Userid && f.SingerId == Singer.Id);

            if(follow == null)
            {
                var NewFoollow = new FollowSinger()
                {
                    SingerId = Singer.Id,
                    UserId = Userid,
                    songer = Singer,
                };

                _context.FollowSingers.Add(NewFoollow);
                _context.SaveChanges();
                return Redirect($"/Sing/SingerAccountDetail?Id={Singer.Id}");
            }
            else
            {
                _context.FollowSingers.Remove(follow);
                _context.SaveChanges();
            }

            return Redirect($"/Sing/SingerAccountDetail?Id={Singer.Id}");
        }
    }
}
