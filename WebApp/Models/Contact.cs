namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int ContactId { get; set; }

        [StringLength(50)]
        public string ContactUserName { get; set; }

        [StringLength(50)]
        public string ContactUserEmail { get; set; }

        [StringLength(100)]
        public string ContactSubject { get; set; }

        [StringLength(1000)]
        public string ContactMessage { get; set; }

        public DateTime ContactDate { get; set; }

        public bool ContactStatus { get; set; }
    }
}
