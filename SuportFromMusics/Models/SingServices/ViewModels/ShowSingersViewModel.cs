namespace SingServices.ViewModels
{
    public class ShowSingersViewModel
    {
        public List<Singer> Singers { get; set; }
        
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}
