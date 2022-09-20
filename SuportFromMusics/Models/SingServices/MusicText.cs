

using SuportFromMusics.Models.SingServices;

namespace SingServices
{
    public class MusicText
    {
        [Key]
        public long Id { get; set; }

        public long SingDetailId { get; set; }

        public List<SongVersies> Verses { get; set; }

    }
}
