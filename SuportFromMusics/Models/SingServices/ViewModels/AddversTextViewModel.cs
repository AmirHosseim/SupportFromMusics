namespace SuportFromMusics.Models.SingServices.ViewModels
{
    public class AddversTextViewModel
    {
        [Required(ErrorMessage = "لطفا متن آهنگ را وارد کنید")]
        public string VersText { get; set; }

        public int VersNumber { get; set; }
    }
}
