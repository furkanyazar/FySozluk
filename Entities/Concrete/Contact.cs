using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string ContactUserName { get; set; }

        [StringLength(50)]
        public string ContactUserEmail { get; set; }

        [StringLength(50)]
        public string ContactSubject { get; set; }

        [StringLength(1000)]
        public string ContactMessage { get; set; }

        public DateTime ContactDate { get; set; }
    }
}
