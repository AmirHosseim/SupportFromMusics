using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;

namespace SuportFromMusics.Pages.Sing.singer
{
    public class SingersListModel : PageModel
    {
        private SuportContext _context;
        private IGetSingers _getSingers { get; set; }
        public SingersListModel(SuportContext context,IGetSingers getsingers)
        {
            _context = context;
            _getSingers = getsingers;
        }

        public ShowSingersViewModel showSingers { get; set; }
        public void OnGet(int pageId = 1)
        {
            var singers = _context.singer.Include(s=> s.Followers)
                .Include(s=> s.singDetails)
                    .OrderByDescending(s=> s.Followers.Count()).ToList();

            showSingers = _getSingers.getSingers(pageId, singers);
        }
    }
}
