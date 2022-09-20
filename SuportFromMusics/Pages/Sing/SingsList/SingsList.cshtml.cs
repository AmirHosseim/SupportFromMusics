using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using SuportFromMusics.Models.SingServices.ViewModels;

namespace SuportFromMusics.Pages.Sing.SingsList
{
    public class SingsListModel : PageModel
    {
        private SuportContext _context;
        private IGetSings _getsings;
        public SingsListModel(SuportContext context, IGetSings getsings)
        {
            _context = context;
            _getsings = getsings;
        }

        public ShowSingsViewModel showSingsVm { get; set; }

        [BindProperty]
        public SingType SingType { get; set; }

        [BindProperty]
        public string searchString { get; set; }
        public IActionResult OnGet(int SingTypeId, int PageId = 1, string SerachString = "")
        {
            SingType = _context.singType.SingleOrDefault(s => s.Id == SingTypeId);

            searchString = SerachString;

            if (SingType == null)
            {
                return NotFound();
            }

            List<SingDetail> Sings = new List<SingDetail>();

            Sings = _context.singDetail.Include(s => s.singer)
                    .Where(s => s.singTypeId == SingTypeId && s.Name.Contains(SerachString)).ToList();


            showSingsVm = _getsings.getSings(PageId, Sings);

            return Page();
        }

        public IActionResult OnPost()
        {
            return OnGet(SingType.Id, 1, searchString);
        }
    }
}
