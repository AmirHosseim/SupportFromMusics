using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    [Authorize]
    public class EditSingModel : PageModel
    {
        private SuportContext _context;

        public EditSingModel(SuportContext suportContext)
        {
            _context = suportContext;
        }

        [BindProperty]
        public SingDetail Sing { get; set; }

        [BindProperty]
        public AddOrEditSingViewModel editSing { get; set; }

        public IActionResult OnGet(long Id)
        {
            var user = _context.user.SingleOrDefault(u => u.Id == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            Sing = _context.singDetail.Include(u => u.singer).SingleOrDefault(s => s.Id == Id && s.singer.UserId == user.Id);

            if (Sing == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(editSing.Name))
            {
                editSing.Name = Sing.Name;
            }

            var sing = _context.singDetail.SingleOrDefault(s => s.Id == Sing.Id);

            if (sing != null)
            {
                sing.Name = editSing.Name;
                _context.SaveChanges();

                if (editSing.Avatar != null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "MusicAvatars",
                        sing.Name + sing.SingerId + sing.Id + Path.GetExtension(editSing.Avatar.FileName));
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        editSing.Avatar.CopyTo(stream);
                    }
                }

            }



            return RedirectToPage("/Account/MyProfile");
        }
    }
}
