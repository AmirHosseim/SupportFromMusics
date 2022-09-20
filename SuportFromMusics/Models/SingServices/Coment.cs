using UserServices;

namespace SingServices
{
    public class Coment
    {
        public long SingDetailId { get; set; }

        public long UserId { get; set; }

        public string coment { get; set; }

        public DateTime sendTime { get; set; }

        public User user { get; set; }
    }
}
