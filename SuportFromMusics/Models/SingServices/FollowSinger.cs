using UserServices;

namespace SingServices
{
    public class FollowSinger
    { 
        public long UserId { get; set; }

        public long SingerId { get; set; }

        public Singer songer { get; set; }

        public User user { get; set; }
    }
}
