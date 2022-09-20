using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Account
{
    [Authorize]
    public class SavesModel : PageModel
    {
        private SuportContext _context;
        public SavesModel(SuportContext context)
        {
            _context = context;
        }

        public IEnumerable<SaveSing> SaveSings { get; set; }
        public void OnGet()
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            SaveSings = _context.SaveSing.
                Include(s=> s.SingDetail)
                    .ThenInclude(s=> s.singer)
                        .Include(s=> s.SingDetail.singType).Where(s => s.UserId == UserId);
        }
    }
}
