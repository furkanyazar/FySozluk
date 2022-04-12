using Entities.Concrete;
using System.Data.Entity;

namespace WebApp.Models
{
    public partial class MvcDemoDbContext : DbContext
    {
        public MvcDemoDbContext()
            : base("name=MvcDemoDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Draft> Drafts { get; set; }
        public virtual DbSet<Heading> Headings { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
