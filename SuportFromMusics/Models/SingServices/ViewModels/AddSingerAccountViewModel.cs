using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingServices.ViewModels
{
    public class AddSingerAccountViewModel
    {

        [MaxLength(50,ErrorMessage ="نام نباید بیشتر از 50 کاراکتر باشد")]
        [Required(ErrorMessage ="لطفا نام را وارد کنید")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "نام خانوادگی نباید بیشتر از 50 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        public string LastName { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsUseFullNameForTitle { get; set; }

        public List<Gender> gender { get; set; }

        public IFormFile SingerAvatar { get; set; }
    }

    public class Gender
    {
        public string gender { get; set; }
    }
}
