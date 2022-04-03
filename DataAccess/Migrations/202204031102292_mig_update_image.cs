namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_update_image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageDescription", c => c.String(maxLength: 1000));
        }

        public override void Down()
        {
            DropColumn("dbo.Images", "ImageDescription");
        }
    }
}
