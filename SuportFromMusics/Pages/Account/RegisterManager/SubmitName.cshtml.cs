using UserServices.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuportFromMusics.Data;
using UserServices;

namespace SuportFromMusics.Pages.Account.RegisterManager
{
    public class SubmitNameModel : PageModel
    {
        private SuportContext _context;
        private readonly IMapper _mapper;

        public SubmitNameModel(SuportContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public AddUserViewModel vm { get; set; }

        [BindProperty]
        public string Email { get; set; }
        public IActionResult OnGet(string email)
        {
            //check is null or not null the user
            var user = _context.user.SingleOrDefault(u => u.Email == email && u.IsFinishedSubName == false);
            if (user == null)
            {
                return NotFound();
            }

            Email = user.Email;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(vm.Email);
            }

            string SecuritPass = "";

            var user = _context.user.SingleOrDefault(u => u.Email == vm.Email);

            if (user != null)
            {
                user.UserName = vm.UserName;
                user.Password = vm.Password;
                user.IsFinishedSubName = true;
                user.Password = vm.Password;

                _context.SaveChanges();
            }

            return Redirect("/");
        }

    }
}
