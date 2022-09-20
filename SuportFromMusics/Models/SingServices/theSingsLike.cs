using SingServices;
using UserServices;

namespace SingServices
{
    public class theSingsLike
    {
        public long SingDetailId { get; set; }

        public long UserId { get; set; }

        public DateTime LikeDate { get; set; }

        public SingDetail SingDetail { get; set; }

        public User User { get; set; }
    }
}
