using UserServices.ViewModels;

namespace UserServices.Repository
{
    public interface IGetUsers
    {
        ShowUsers getUsers(int PageId, List<User> users);
    }

    public class GetUsers : IGetUsers
    {
        public ShowUsers getUsers(int PageId, List<User> users)
        {
            int take = 30;
            int skip = (PageId - 1) * take;

            ShowUsers list = new();

            list.CurrentPage = PageId;
            list.PageCount = (int)Math.Ceiling(users.Count() / (double)take);

            list.users = users.Skip(skip).Take(take).ToList();

            return list;
        }
    }

}
