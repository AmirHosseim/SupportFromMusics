using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices.ViewModels;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.Suport
{
    [Authorize]
    public class AddSuportFormModel : PageModel
    {
        private SuportContext _context;
        public AddSuportFormModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SingDetail Sing { get; set; }
        public AddSuportFormViewModel addSuportVm { get; set; }
        [BindProperty]
        public List<MaxValues> maxValues { get; set; }

        [BindProperty]
        public decimal SelectedMaxValue { get; set; }
        public IActionResult OnGet(int SingId)
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Sing = _context.singDetail.Include(s => s.singer).SingleOrDefault(s => s.Id == SingId && s.singer.UserId == UserId);

            if (Sing == null)
            {
                return NotFound();
            }

            maxValues = new List<MaxValues>()
            {
                new MaxValues{Maxvalue = 10000000},
                new MaxValues{Maxvalue = 20000000},
                new MaxValues{Maxvalue = 30000000},
                new MaxValues{Maxvalue = 40000000},
                new MaxValues{Maxvalue = 60000000},
                new MaxValues{Maxvalue = 70000000},
                new MaxValues{Maxvalue = 80000000},
                new MaxValues{Maxvalue = 90000000},
                new MaxValues{Maxvalue = 100000000},
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (SelectedMaxValue == 0)
            {
                ViewData["error"] = "لطفا سقف مبلغ را وارد کنید";
                return OnGet(Sing.Id);
            }

            var NewSuportForm = new SuportForm()
            {
                SingDetailId = Sing.Id,
                SuportValue = SelectedMaxValue,
                Suportedvalue = 0,
            };

            _context.SuportForm.Add(NewSuportForm);
            _context.SaveChanges();

            var sing = _context.singDetail.SingleOrDefault(s => s.Id == Sing.Id);

            sing.SuportId = NewSuportForm.Id;

            _context.SaveChanges();

            return RedirectToPage("/Sing/SingDetail", new { Id = NewSuportForm.SingDetailId });

        }
    }
}
