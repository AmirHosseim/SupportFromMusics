using SingServices;

namespace SuportFromMusics.Models.SingServices
{
    public class MusicVersies
    {

        [Key]
        public long Id { get; set; }

        public long MusicTextId { get; set; }

        public string Text { get; set; }

        public long SingDetailId { get; set; }

        public MusicText MusicText { get; set; }

        public SingDetail SingDetail { get; set; }
    }
}
