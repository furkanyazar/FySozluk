namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_update_message_for_deleted_messages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageIsDeleted", c => c.Boolean(nullable: false));
            DropTable("dbo.Trashes");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Trashes",
                c => new
                {
                    TrashId = c.Int(nullable: false, identity: true),
                    MessageSubject = c.String(maxLength: 100),
                    MessageContent = c.String(maxLength: 1000),
                    SenderEmail = c.String(maxLength: 50),
                    ReceiverEmail = c.String(maxLength: 50),
                    MessageDate = c.DateTime(nullable: false),
                    MessageStatus = c.Boolean(nullable: false),
                    MessageIsReceived = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.TrashId);

            DropColumn("dbo.Messages", "MessageIsDeleted");
        }
    }
}
