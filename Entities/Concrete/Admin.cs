using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
