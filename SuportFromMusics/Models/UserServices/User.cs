global using System.ComponentModel.DataAnnotations;
using SingServices;

namespace UserServices
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PhonNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsFinishedSubName { get; set; }

        public List<FollowSinger> Following { get; set; }

        public List<SuportedUsers> Supoertedusers { get; set; }

        public List<theSingsLike> Likes { get; set; }

        public List<SaveSing> Saves { get; set; }

        public List<Coment> Coments { get; set; }
    }
}