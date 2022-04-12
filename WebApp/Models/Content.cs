namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Content
    {
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentText { get; set; }

        public DateTime ContentDate { get; set; }

        public int HeadingId { get; set; }

        public int? WriterId { get; set; }

        public bool ContentStatus { get; set; }

        public virtual Heading Heading { get; set; }

        public virtual Writer Writer { get; set; }
    }
}
