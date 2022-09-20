using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing.coments
{
    public class AllcomentsModel : PageModel
    {
        private SuportContext _context;
        public AllcomentsModel(SuportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddComentViewModel addComent { get; set; }

        public List<Coment> Coments { get; set; }

        [BindProperty]
        public long singDetailid { get; set; }
        public IActionResult OnGet(long SingDetailId)
        {
            singDetailid = SingDetailId;
            Coments = _context.Coment.Include(s=> s.user).Where(c => c.SingDetailId == SingDetailId).ToList();

            return Page();
        }

        [Authorize]
        public IActionResult OnPost()
        {
            if(addComent.coment != null)
            {
                var user = _context.user.SingleOrDefault(u => u.Id == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                var newComent = new Coment()
                {
                    coment = addComent.coment,
                    SingDetailId = singDetailid,
                    UserId = user.Id,
                    sendTime = DateTime.Now,
                };

                _context.Coment.Add(newComent);
                _context.SaveChanges();
            }

            return OnGet(singDetailid);
        }
    }
}
