namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_writer_update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterImageUrl", c => c.String(maxLength: 250));
        }

        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImageUrl", c => c.String(maxLength: 100));
        }
    }
}
