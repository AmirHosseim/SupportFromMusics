using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.singer
{
    [Authorize]
    public class AddSingerAccountModel : PageModel
    {
        private SuportContext _context;
        public AddSingerAccountModel(SuportContext context)
        {
            _context = context;
        }
            
        [BindProperty]
        public AddSingerAccountViewModel _addSingervm { get; set; }

        [BindProperty]
        public List<Gender> gender { get; set; }
        public SingServices.Singer songer { get; set; }

        [BindProperty]
        public string SelectGender { get; set; }

        #region OnGet Method
        public IActionResult OnGet()
        { 
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            songer = _context.singer.SingleOrDefault(s => s.UserId == UserId);
            gender = new List<Gender>(){
                new Gender{gender = "مرد"},
                new Gender{gender = "زن"},
            };

            return Page();
        }
        #endregion

        #region OnPost method
        public IActionResult OnPost()
        {
            if (_addSingervm.LastName == null || _addSingervm.FirstName == null || SelectGender == null || 
                    _addSingervm.IsUseFullNameForTitle == false && _addSingervm.Title == null)
            {
                ViewData["errorMessage"] = "لطفا تمام فیلد هارا پر کنید";
                return OnGet();
            }
            
            if(_addSingervm.IsUseFullNameForTitle == true)
            {
                _addSingervm.Title = _addSingervm.FirstName + " " + _addSingervm.LastName;
            }

            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

            var NewSinger = new SingServices.Singer() { 
                FirstName = _addSingervm.FirstName,
                LastName = _addSingervm.LastName,
                title = _addSingervm.Title,
                UserId = UserId,
                Gender = SelectGender,
                ShortLink = GenerateShortKey(),
            };

            _context.singer.Add(NewSinger);
            _context.SaveChanges();

            if (_addSingervm.SingerAvatar != null)
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "SingerAvatar",
                    NewSinger.title + NewSinger.Id + Path.GetExtension(_addSingervm.SingerAvatar.FileName));
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    _addSingervm.SingerAvatar.CopyTo(stream);
                }
            }

            return RedirectToPage("/Account/MyProfile");
        }

        #endregion

        #region GenerateShortKey method
        public string GenerateShortKey(int lenght = 5)
        {
            string Key = Guid.NewGuid().ToString().Replace("_", "").Substring(0, lenght);

            while(_context.singer.Any(s=> s.ShortLink == Key))
            {
                Key = Guid.NewGuid().ToString().Replace("_", "").Substring(0, lenght);
            }

            return Key;
        }
        #endregion
    }
}
