using UserServices;

namespace SingServices
{
    public class SuportedUsers
    {
        public long UserId { get; set; }

        public long SuportFormId { get; set; }

        public decimal SuportedValue { get; set; } 

        public SuportForm SuportForm { get; set; }

        public User User { get; set; }
    }
}
