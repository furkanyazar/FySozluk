namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_add_draft : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                {
                    DraftId = c.Int(nullable: false, identity: true),
                    DraftSubject = c.String(maxLength: 100),
                    DraftContent = c.String(maxLength: 1000),
                    SenderEmail = c.String(maxLength: 50),
                    ReceiverEmail = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.DraftId);
        }

        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
