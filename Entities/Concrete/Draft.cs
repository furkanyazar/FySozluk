using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Draft : IEntity
    {
        [Key]
        public int DraftId { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        [StringLength(1000)]
        public string MessageContent { get; set; }

        [StringLength(50)]
        public string SenderEmail { get; set; }

        [StringLength(50)]
        public string ReceiverEmail { get; set; }
    }
}
