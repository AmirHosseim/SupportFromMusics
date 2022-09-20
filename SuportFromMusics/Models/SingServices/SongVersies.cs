using SingServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuportFromMusics.Models.SingServices
{
    public class SongVersies
    {
        [Key]
        public long Id { get; set; }
        
        public string Text { get; set; }

        public long TextMusciId { get; set; }

        public long SingDetailId { get; set; }
            
        public int VersNumber { get; set; }

        //public TextMusicVerses TextMusic { get; set; }

        //public SingDetail SingDetail { get; set; }
    }
}
