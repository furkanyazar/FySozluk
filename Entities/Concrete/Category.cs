using Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(250)]
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; } = true;

        public ICollection<Heading> Headings { get; set; }
    }
}
