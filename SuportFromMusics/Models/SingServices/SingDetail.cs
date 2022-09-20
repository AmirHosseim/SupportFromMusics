using SuportFromMusics.Models.SingServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingServices
{
    public class SingDetail
    {
        [Key]
        public int Id { get; set; }

        public long MusicTextId { get; set; }
        
        public int SingerId { get; set; }

        public long SuportId { get; set; }
        
        public int singTypeId { get; set; }

        public string Name { get; set; }

        public Singer singer { get; set; }

        public DateTime SharedTime { get; set; }

        [ForeignKey("singTypeId")]
        public SingType singType { get; set; }

        public List<SongVersies> Versies { get; set; }

        public List<SingLike> Likes { get; set; }

        public List<SaveSing> Saves { get; set; }

    }
}
