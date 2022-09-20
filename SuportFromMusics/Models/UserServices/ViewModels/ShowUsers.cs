namespace UserServices.ViewModels
{
    public class ShowUsers
    {
        public int PageCount { get; set; }

        public int CurrentPage { get; set; }

        public List<User> users { get; set; }
    }
}
