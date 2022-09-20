using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Sing.SingsList
{
    [Route("Best")]
    public class BestSingsModel : PageModel
    {
        private SuportContext _context;
        private IGetSings _getSings;
        public BestSingsModel(SuportContext context,IGetSings getSings)
        {
            _context = context;
            _getSings = getSings;
        }

        //public IEnumerable<SingDetail> Sings { get; set; }
        public ShowSingsViewModel showSings = new ShowSingsViewModel();
        public void OnGet(int pageid = 1)
        {
            List<SingDetail> sings = _context.singDetail.Include(s => s.singer).Include(s=> s.singType)
                .Include(s => s.theSingsLike).ToList();
            sings.OrderByDescending(s => s.theSingsLike.Count()).TakeLast(50);

            showSings = _getSings.getSings(pageid,sings.ToList());

            //showSings.SingDetails.OrderByDescending(s => s.Likes.Count()).TakeLast(50);
        }
    }
}
