using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;
using UserServices;

namespace SuportFromMusics.Pages.Sing
{
    [Authorize]
    public class AddSingModel : PageModel
    {
        private SuportContext _context;

        public AddSingModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddOrEditSingViewModel singvm { get; set; }

        [BindProperty]
        public IEnumerable<SingType> SingTypes { get; set; }

        //this praperty is for select type of the sing
        [BindProperty]
        public int SelectType { get; set; } 

        public SingServices.Singer Singer { get; set; }

        
        public IActionResult OnGet()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());            

            Singer = _context.singer.SingleOrDefault(s => s.UserId == userid);

            if (Singer == null)
            {
                ViewData["Error"] = "شما حساب خانندگی برای ثبت ترک ندارید";
                return Page();
            }

            SingTypes = _context.singType.ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //    return Page();

            if (SelectType == 0)
            {
                ViewData["ErrorMessage"] = "لطفا نوع محصول را وارد کنید";
                return OnGet();
            }

            var singer = _context.singer.SingleOrDefault(s => s.UserId ==
                    int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()));

            var NewSing = new SingDetail()
            {
                Name = singvm.Name,
                SingerId = singer.Id,
                SharedTime = DateTime.Now,
                singTypeId = SelectType,
            };

            _context.singDetail.Add(NewSing);
            _context.SaveChanges();

            try
            {
                if (singvm.Avatar != null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "MusicAvatars",
                        NewSing.Name + NewSing.SingerId + NewSing.Id + Path.GetExtension(singvm.Avatar.FileName));
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        singvm.Avatar.CopyTo(stream);
                    }
                }

                if (singvm.Audio != null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "Audios",
                        NewSing.Name + NewSing.SingerId + NewSing.Id + Path.GetExtension(singvm.Audio.FileName));
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        singvm.Audio.CopyTo(stream);
                    }
                }
            }
            catch
            {
                return OnGet();   
            }

            return RedirectToPage("/Account/MyProfile");
        }
    }
}
