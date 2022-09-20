using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingServices.ViewModels
{
    public class AddOrEditSingViewModel
    {
        [Required(ErrorMessage ="لطفا نام را وارد کنید")]
        [MaxLength(50,ErrorMessage ="نام نمی تواند بیشتر از 50 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا آواتار موسیقی را وارد کنید")]
        public IFormFile Avatar { get; set; }

        [Required(ErrorMessage = "لطفا فایل صوتی را وارد کنید")]
        public IFormFile Audio { get; set; }

        public List<SingType> singTypes { get; set; }
    }
}
