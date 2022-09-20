using System.ComponentModel.DataAnnotations.Schema;

namespace SingServices
{
    public class SuportForm
    {
        [Key]
        public long Id { get; set; }

        public long SingDetailId { get; set; }

        public decimal SuportValue { get; set; } 

        public decimal Suportedvalue { get; set; }

        //[ForeignKey("SingId")]
        //public SingDetail SingDetail { get; set; }

        public List<SuportedUsers> SuportedUsers { get; set; }
    }
}
