using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingServices
{
    public class Sing
    {
        [Key]
        public long Id { get; set; }

        public FileStream Music { get; set; }

        public FileStream PectureOfMusic { get; set; }
    }
}
