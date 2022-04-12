namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int MessageId { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        [StringLength(1000)]
        public string MessageContent { get; set; }

        [StringLength(50)]
        public string SenderEmail { get; set; }

        [StringLength(50)]
        public string ReceiverEmail { get; set; }

        public DateTime MessageDate { get; set; }

        public bool MessageStatus { get; set; }

        public bool MessageIsDeleted { get; set; }
    }
}
