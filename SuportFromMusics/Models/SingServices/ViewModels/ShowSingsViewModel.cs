using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingServices.ViewModels
{
    public class ShowSingsViewModel
    {
        public List<SingDetail> SingDetails { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}
