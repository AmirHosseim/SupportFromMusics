using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SingServices;
using SingServices.Repository;
using SingServices.ViewModels;
using SuportFromMusics.Data;
using System.Collections.Generic;

namespace SuportFromMusics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private SuportContext _context;
        public IndexModel(ILogger<IndexModel> logger,SuportContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<SingDetail> SingDetails { get; set; }
        public void OnGet()
        {
            SingDetails = _context.singDetail.Include(s=> s.singer).Include(s=> s.singType).ToList();

            SingDetails.OrderByDescending(s => s.SharedTime);
        }
    }
}