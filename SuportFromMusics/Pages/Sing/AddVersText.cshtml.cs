using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices;
using SuportFromMusics.Models.SingServices.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    public class AddVersTextModel : PageModel
    {
        private SuportContext _context;
        public AddVersTextModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddversTextViewModel AddVersVM { get; set; }

        [BindProperty]
        public SingDetail Sing { get; set; }

        [BindProperty]
        public IEnumerable<SongVersies> Verses { get; set; }
        public IActionResult OnGet(int SingId)
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            int singerId = _context.singer.SingleOrDefault(s => s.UserId == UserId).Id;

            if (singerId == 0)
            {
                return NotFound();
            }

            Sing = _context.singDetail.Include(s => s.Versies).SingleOrDefault(s => s.Id == SingId && singerId == singerId);

            Verses = _context.SongVersies.Where(s => s.SingDetailId == Sing.Id).OrderBy(v => v.VersNumber);
            
            return Page();
        }

        public IActionResult OnPost()
        {
            if(AddVersVM.VersText == "" || AddVersVM.VersNumber == 0)
            {
                ViewData["ErrorMessage"] = "لطفا تمام المان هارا پر کنید";
                return OnGet(Sing.Id);
            }

            //get MusicText for check null or have value
            var MusicText = _context.MusicTexts.Include(v => v.Verses).SingleOrDefault(s => s.SingDetailId == Sing.Id);

            if (MusicText == null)
            {
                var NewMusicText = new MusicText()
                {
                    SingDetailId = Sing.Id
                };

                _context.MusicTexts.Add(NewMusicText);
                _context.SaveChanges();
                MusicText = NewMusicText;
            }

            if (_context.SongVersies.FirstOrDefault(v => v.VersNumber == AddVersVM.VersNumber && v.SingDetailId == Sing.Id) != null)
            {
                ViewData["ErrorMessage"] = "ورس با این شماره از قبل موجود است";
                return OnGet(Sing.Id);
            }

            var NewVers = new SongVersies()
            {
                Text = AddVersVM.VersText,
                SingDetailId = Sing.Id,
                VersNumber = AddVersVM.VersNumber,
                TextMusciId = MusicText.Id
            };

            _context.SongVersies.Add(NewVers);
            _context.SaveChanges();

            return OnGet(Sing.Id);
        }

        // Order the Versies form litle to Order by vers number
        private List<SongVersies> OrderQuitVerseiesByVersNumber(List<SongVersies> versies,int SingId)
        {

            List<SongVersies> v = _context.SongVersies.Where(v => v.SingDetailId == SingId).ToList();

            v.OrderBy(v => v.VersNumber);

            for (int i = 0; i < v.Count(); i++)
            {
                int x = (v.Count() - i) - 1;
                versies.Append(v[x]);
            }

            return versies;
        }

    }
}
