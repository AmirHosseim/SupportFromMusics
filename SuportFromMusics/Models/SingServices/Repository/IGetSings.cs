using SingServices.ViewModels;
using System;
using SuportFromMusics.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SingServices.Repository
{
    public interface IGetSings
    {
        ShowSingsViewModel getSings(int PageId,List<SingDetail> sings);
    }

    public class GetSings : IGetSings
    {
        
        public ShowSingsViewModel getSings(int PageId,List<SingDetail> sings)
        {

            int Take = 10;

            int Skip = (PageId - 1) * Take;

            ShowSingsViewModel list = new();

            list.CurrentPage = PageId;
            list.PageCount = (int)Math.Ceiling(sings.Count() / (double)Take);

            list.SingDetails = sings.OrderBy(u => u.Id).Skip(Skip).Take(Take).ToList();

            return list;
        }
    }
}
