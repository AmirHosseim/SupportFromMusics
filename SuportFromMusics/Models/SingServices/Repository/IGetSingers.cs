using SingServices.ViewModels;

namespace SingServices.Repository
{
    public interface IGetSingers
    {
        ShowSingersViewModel getSingers(int PageId, List<Singer> Singers);
    }

    public class GetSingers : IGetSingers
    {
        public ShowSingersViewModel getSingers(int PageId, List<Singer> Singers)
        {
            int take = 20;

            int Skip = (PageId - 1) * take;

            ShowSingersViewModel list = new();

            list.CurrentPage = PageId;
            list.PageCount = (int)Math.Ceiling(Singers.Count() / (double)take);

            list.Singers = Singers.Skip(Skip).Take(take).ToList();

            return list;
        }
    }

}
