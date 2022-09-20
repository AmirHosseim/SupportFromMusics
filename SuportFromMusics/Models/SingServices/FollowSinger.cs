using UserServices;

namespace SingServices
{
    public class FollowSinger
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        public long SingerId { get; set; }

        public Singer songer { get; set; }

        public User user { get; set; }
    }
}
