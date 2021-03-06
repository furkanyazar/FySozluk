using Entities.Concrete;
using System.Data.Entity;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        public Context()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
