using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices.ViewModels;
using System.Security.Claims;
using UserServices;
using UserServices.Services;

namespace SuportFromMusics.Pages.Sing.Suport
{
    public class SuporttingModel : PageModel
    {
        private SuportContext _context;
        public SuporttingModel(SuportContext context)
        {
            _context = context;
        }
        [BindProperty]
        public SuportForm SuportForm { get; set; }

        [BindProperty]
        public SuporttingViewModel _suporttingVm { get; set; }
        public IActionResult OnGet(long SuportFormId)
        {
            SuportForm = _context.SuportForm.SingleOrDefault(s => s.Id == SuportFormId);

            if (SuportForm == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (_suporttingVm.SuportValue == 0)
            {
                ViewData["ErrorMessage"] = "لطفا مقدار همایت را وارد کنید";
                return OnGet(SuportForm.Id);
            }


            if (_suporttingVm.SuportValue > SuportForm.SuportValue - SuportForm.Suportedvalue)
            {
                ViewData["ErrorMessage"] = $"مقدار همایت نمی تواند بیشتر از {SuportForm.SuportValue - SuportForm.Suportedvalue} باشد";
                return OnGet(SuportForm.Id);
            }

            var suportedUser = _context.SuportedUsers.FirstOrDefault(s =>
                    s.UserId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && s.SuportFormId == SuportForm.Id);


            if (suportedUser == null)
            {
                suportedUser = new SuportedUsers()
                {
                    SuportFormId = SuportForm.Id,
                    SuportedValue = _suporttingVm.SuportValue,
                    UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                };
                _context.SuportedUsers.Add(suportedUser);
            }
            else
            {
                suportedUser.SuportedValue += _suporttingVm.SuportValue;
            }

            var suportForm = _context.SuportForm.SingleOrDefault(s => s.Id == SuportForm.Id);

            suportForm.Suportedvalue += _suporttingVm.SuportValue;

            _context.SaveChanges();

            return Redirect($"/Sing/SingDetail?Id={suportForm.SingDetailId}");

        }

    }
}
