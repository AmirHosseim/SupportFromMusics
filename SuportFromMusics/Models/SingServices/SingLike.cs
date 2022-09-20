using UserServices;

namespace SingServices
{
    public class SingLike
    {
        [Key]
        public long Id { get; set; }

        public long SingDetailId { get; set; }

        public long UserId { get; set; }


        public SingDetail SingDetail { get; set; }

        public User User { get; set; }
    }
}
