namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Writer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Writer()
        {
            Contents = new HashSet<Content>();
            Headings = new HashSet<Heading>();
        }

        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterFirstName { get; set; }

        [StringLength(50)]
        public string WriterLastName { get; set; }

        [StringLength(250)]
        public string WriterImageUrl { get; set; }

        [StringLength(50)]
        public string WriterEmail { get; set; }

        [StringLength(500)]
        public string WriterPassword { get; set; }

        [StringLength(250)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Heading> Headings { get; set; }
    }
}
