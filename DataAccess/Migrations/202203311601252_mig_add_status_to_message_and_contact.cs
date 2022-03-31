namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_add_status_to_message_and_contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Contacts", "ContactStatus");
        }
    }
}
