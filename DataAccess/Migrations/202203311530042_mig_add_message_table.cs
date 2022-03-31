namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_add_message_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessageId = c.Int(nullable: false, identity: true),
                    MessageSubject = c.String(maxLength: 100),
                    MessageContent = c.String(maxLength: 1000),
                    SenderEmail = c.String(maxLength: 50),
                    ReceiverEmail = c.String(maxLength: 50),
                    MessageDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.MessageId);

            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contacts", "ContactSubject", c => c.String(maxLength: 100));
        }

        public override void Down()
        {
            AlterColumn("dbo.Contacts", "ContactSubject", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 200));
            DropTable("dbo.Messages");
        }
    }
}
