using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    
    public class DeletSingModel : PageModel
    {
        private SuportContext _context;
        public DeletSingModel(SuportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long Id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var sing = _context.singDetail.Include(s=> s.singer).SingleOrDefault(s => s.Id == Id && s.singer.UserId == userId);

            if(sing == null)
            {
                return NotFound();
            }

            List<SongVersies> versies = _context.SongVersies.Where(s => s.SingDetailId == sing.Id).ToList();

            if (versies.Count != 0)
            {
                _context.MusicTexts.SingleOrDefault(s => s.SingDetailId == Id);
                DeletVers(versies);
            }

            var SForm = _context.SuportForm.SingleOrDefault(s => s.SingDetailId == sing.Id);
            var Coments = _context.Coment.Where(s => s.SingDetailId == sing.Id).ToList();
            if (SForm != null)
                DeletSuportForm(SForm);

            if(Coments.Count > 0)
            {
                _context.Coment.RemoveRange(Coments);
            }

            _context.singDetail.Remove(sing);
            _context.SaveChanges();

            return RedirectToPage("/Account/MyProfile");
        }

        public void DeletVers(List<SongVersies> Versies)
        {
            _context.SongVersies.RemoveRange(Versies);
        }

        public void DeletSuportForm(SuportForm form)
        {
            _context.SuportForm.Remove(form);
            _context.SuportedUsers.RemoveRange(_context.SuportedUsers.Where(u => u.SuportFormId == form.Id));
        }
    }
}
