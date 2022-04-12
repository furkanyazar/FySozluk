namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class About
    {
        public int AboutId { get; set; }

        [StringLength(1000)]
        public string AboutDetails1 { get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(250)]
        public string AboutImageUrl1 { get; set; }

        [StringLength(250)]
        public string AboutImageUrl2 { get; set; }
    }
}
