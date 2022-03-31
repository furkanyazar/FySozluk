using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        [StringLength(1000)]
        public string MessageContent { get; set; }

        [StringLength(50)]
        public string SenderEmail { get; set; }

        [StringLength(50)]
        public string ReceiverEmail { get; set; }

        public DateTime MessageDate { get; set; } = DateTime.Now;

        public bool MessageStatus { get; set; } = false;
    }
}
