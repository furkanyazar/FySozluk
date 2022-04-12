namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Draft
    {
        public int DraftId { get; set; }

        [StringLength(50)]
        public string SenderEmail { get; set; }

        [StringLength(50)]
        public string ReceiverEmail { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        [StringLength(1000)]
        public string MessageContent { get; set; }
    }
}
