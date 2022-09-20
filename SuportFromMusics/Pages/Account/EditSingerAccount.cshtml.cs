using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Account
{
    [Authorize]
    public class EditSingerAccountModel : PageModel
    {
        private SuportContext _context;
        public EditSingerAccountModel(SuportContext context)
        {
            _context = context;
        }

        //this viewModel is for edit and add
        [BindProperty]
        public AddSingerAccountViewModel editSingerAccount { get; set; }

        [BindProperty]
        public Singer Singer { get; set; }
        public IActionResult OnGet()
        {
            Singer = _context.singer.SingleOrDefault(s => s.UserId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (Equals(Singer, null))
            {
                ViewData["ErrorMessage"] = "شما اکانت خوانندگی ندارید";
            }
            else
            {
                editSingerAccount = new()
                {
                    FirstName = Singer.FirstName,
                    LastName = Singer.LastName,
                    Title = Singer.title,
                };
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (editSingerAccount.FirstName == null || editSingerAccount.LastName == null || editSingerAccount.Title == null)
            {
                ViewData["errorMessage"] = "لطفا تمام المان هارا پر کنید";
                return OnGet();
            }

            var singer = _context.singer.SingleOrDefault(s => s.Id == Singer.Id);

            if (singer != null)
            {
                singer.FirstName = editSingerAccount.FirstName;
                singer.LastName = editSingerAccount.LastName;
                singer.title = editSingerAccount.Title;

                _context.SaveChanges();

                if (editSingerAccount.SingerAvatar != null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "SingerAvatar",
                        singer.title + singer.Id + Path.GetExtension(editSingerAccount.SingerAvatar.FileName));

                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        editSingerAccount.SingerAvatar.CopyTo(stream);
                    }
                }

            }

            return RedirectToPage("MyProfile");
        }
    }
}
