using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Content : IEntity
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentText { get; set; }

        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; } = true;

        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
