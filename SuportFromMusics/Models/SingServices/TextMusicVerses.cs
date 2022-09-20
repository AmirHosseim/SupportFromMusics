using System.ComponentModel.DataAnnotations.Schema;

namespace SingServices
{
    public class TextMusicVerses
    {
        [Key]
        public long id { get; set; }

        public long MusicTextId { get; set; }

        public string Text { get; set; }       
        
        public long SingDetailId { get; set; }

        public MusicText MusicText { get; set; }
        public SingDetail SingDetail { get; set; }
    }
}
