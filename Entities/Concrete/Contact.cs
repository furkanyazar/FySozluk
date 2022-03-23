using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string ContactUserName { get; set; }

        [StringLength(50)]
        public string ContactUserEmail { get; set; }

        [StringLength(50)]
        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }
    }
}
