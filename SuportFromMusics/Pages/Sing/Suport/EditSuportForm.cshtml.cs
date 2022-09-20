using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices.ViewModels;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.Suport
{
    public class EditSuportFormModel : PageModel
    {
        private SuportContext _context;
        public EditSuportFormModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<MaxValues> maxValues { get; set; }

        [BindProperty]
        public SuportForm suportForm { get; set; }

        [BindProperty]
        public decimal SelectedMaxValue { get; set; }
        public IActionResult OnGet(long Id)
        {
            suportForm = _context.SuportForm.SingleOrDefault(s => s.Id == Id);

            if (suportForm == null)
            {
                return NotFound();
            }

            var sing = _context.singDetail.Include(s=> s.singer).SingleOrDefault(s => s.Id == suportForm.Id);
            

            if (sing.singer.UserId != int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return NotFound();


            decimal i = suportForm.SuportValue + 10000000;

            maxValues = new List<MaxValues>();

            while (i <= 100000000)
            {
                maxValues.Add(new MaxValues { Maxvalue = i });
                i += 10000000;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var form = _context.SuportForm.SingleOrDefault(s => s.Id == suportForm.Id);

            if (SelectedMaxValue != 0)
            {
                form.SuportValue = SelectedMaxValue;

                _context.SaveChanges();
            }

            return RedirectToPage("SuportFormInfo", new { SuportId = form.Id });
        }
    }
}
