using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        [StringLength(1000)]
        public string ImageDescription { get; set; }
    }
}
