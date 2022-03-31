using Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterFirstName { get; set; }

        [StringLength(50)]
        public string WriterLastName { get; set; }

        [StringLength(250)]
        public string WriterImageUrl { get; set; }

        [StringLength(250)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        [StringLength(50)]
        public string WriterEmail { get; set; }

        [StringLength(250)]
        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; } = true;

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
