global using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingServices
{
    public class Singer
    {
        [Key]
        public int Id { get; set; }
        
        public string ShortLink { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string title { get; set; }

        public string Gender { get; set; }

        public int UserId { get; set; }

        public List<SingDetail> singDetails { get; set; }

        public List<FollowSinger> Followers { get; set; }
    }
}