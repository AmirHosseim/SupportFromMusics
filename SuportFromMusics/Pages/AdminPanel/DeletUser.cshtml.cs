using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.AdminPanel
{
    public class DeletUserModel : PageModel
    {
        private SuportContext _context;
        public DeletUserModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long Id)
        {
            if (!bool.Parse(User.FindFirstValue("IsAdmin")))
                return NotFound();

            var user = _context.user.Include(u=> u.Following)
                    .Include(u=> u.Supoertedusers)
                        .Include(s=> s.Likes).Include(c=> c.Coments).Include(s=> s.Saves).SingleOrDefault(s => s.Id == Id);

            if (user == null)
            {
                return NotFound();
            }

            //_context.RemoveRange(user.Saves, user.Following,user.Supoertedusers);

            _context.SaveSing.RemoveRange(user.Saves);
            _context.FollowSingers.RemoveRange(user.Following);
            _context.SuportedUsers.RemoveRange(user.Supoertedusers);
            _context.Coment.RemoveRange(user.Coments);

            var singer = _context.singer.Include(s=> s.singDetails).SingleOrDefault(s => s.UserId == user.Id);
            _context.singer.Remove(singer);

            _context.singDetail.RemoveRange(singer.singDetails);

            _context.Remove(user);

            _context.SaveChanges();

            return RedirectToPage("Usersmanager");
        }
    }
}
