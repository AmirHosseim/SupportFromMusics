using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SuportFromMusics.Data;
using System.Collections.Generic;

namespace SuportFromMusics.Pages.Sing.SingsList
{
    public class SingtypesModel : PageModel
    {
        private SuportContext _context;
        public SingtypesModel(SuportContext context)
        {
            _context = context;
        }

        public Dictionary<SingType, List<SingDetail>> SingType_SingTypes = new Dictionary<SingType, List<SingDetail>>();
        public void OnGet()
        {
            var SingTypes = _context.singType.Include(s=> s.singDetail).Where(s=> s.singDetail.Count() != 0).ToList();

            foreach(var item in SingTypes)
            { 
                SingType_SingTypes.Add(item, _context.singDetail.Include(s=> s.singer).Where(s=> s.singTypeId == item.Id).ToList());
            }
        }
    }
}
