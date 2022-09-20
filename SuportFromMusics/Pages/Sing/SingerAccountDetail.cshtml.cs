using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using System.Collections.Generic;
using System.Security.Claims;

namespace SuportFromMusics.Pages.Sing
{
    public class SingerAccountDetailModel : PageModel
    {
        private SuportContext _context { get; set; }

        public SingerAccountDetailModel(SuportContext context)
        {
            _context = context;
        }
        public SingServices.Singer singer { get; set; }
        public IEnumerable<SingDetail> Sings { get; set; }
        public List<SingType> SingTypes { get; set; }
        public FollowSinger Follow { get; set; }
        public IActionResult OnGet(int Id)
        {
            singer = _context.singer.Include(s=> s.Followers).SingleOrDefault(s => s.Id == Id);

            if (singer == null)
            {
                ViewData["errorMessage"] = "حسابی یافت نشد";
                return Page();
            }
            else
            {
                Sings = _context.singDetail.Include(s => s.singType).Where(s => s.SingerId == singer.Id);

                SingTypes = SetSingTypesValue(Sings.ToList());
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

#pragma warning disable CS8601 // Possible null reference assignment.
                Follow = _context.FollowSingers.SingleOrDefault(f => f.UserId == userid && f.SingerId == singer.Id);
#pragma warning restore CS8601 // Possible null reference assignment.
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return Page();
        }

        //this method is for set the singtypes value
        public List<SingType> SetSingTypesValue(List<SingDetail> sings)
        {
            List<SingType> singTypes = new List<SingType>();

            foreach (var item in sings)
            {
                if (singTypes == null)
                {
                    singTypes.Add(item.singType);
                }
                else if (!singTypes.Contains(item.singType))
                {
                    singTypes.Add(item.singType);
                }
            }

            return singTypes;
        }
    }
}
