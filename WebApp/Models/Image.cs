namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int ImageId { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        [StringLength(1000)]
        public string ImageDescription { get; set; }
    }
}
