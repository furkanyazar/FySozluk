using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(1000)]
        public string AboutDetails1 { get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImageUrl1 { get; set; }

        [StringLength(100)]
        public string AboutImageUrl2 { get; set; }
    }
}
