namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        public int AdminId { get; set; }

        [StringLength(500)]
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }

        [StringLength(50)]
        public string AdminEmail { get; set; }

        public bool AdminStatus { get; set; }

        [StringLength(50)]
        public string AdminFirstName { get; set; }

        [StringLength(50)]
        public string AdminLastName { get; set; }
    }
}
