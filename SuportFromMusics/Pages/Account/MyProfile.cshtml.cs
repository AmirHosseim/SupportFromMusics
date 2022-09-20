using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;
using UserServices;

namespace SuportFromMusics.Pages.Account
{
    [Authorize]
    public class MyProfileModel : PageModel
    {
        private SuportContext _context;
        public MyProfileModel(SuportContext context)
        {
            _context = context;
        }

        public User user { get; set; }

        public Singer singer { get; set; }

        
        public void OnGet()
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

            user = _context.user.SingleOrDefault(u => u.Id == UserId);

            singer = _context.singer.Include(s=> s.singDetails).ThenInclude(s=> s.singType).SingleOrDefault(s => s.UserId == user.Id);
        }
    }
}
