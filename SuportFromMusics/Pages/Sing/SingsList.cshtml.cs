using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Sing
{
    public class SingsListModel : PageModel
    {
        private SuportContext _context;
        private IGetSings _getsings;
        public SingsListModel( SuportContext context, IGetSings getsings)
        {
            _context = context;
            _getsings = getsings;
        }

        public IEnumerable<SingDetail> SingDetails { get; set; }
        public ShowSingsViewModel showSingsvm { get; set; }
        public void OnGet(int PageId = 1)
        {
            SingDetails = _context.singDetail.Include(s => s.singer).Include(s => s.singType).ToList();

            SingDetails.OrderByDescending(s => s.SharedTime);

            showSingsvm = _getsings.getSings(PageId, SingDetails.ToList());
        }
    }
}
