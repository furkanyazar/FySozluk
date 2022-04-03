namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_add_image : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                {
                    ImageId = c.Int(nullable: false, identity: true),
                    ImageName = c.String(maxLength: 50),
                    ImagePath = c.String(maxLength: 250),
                })
                .PrimaryKey(t => t.ImageId);
        }

        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
