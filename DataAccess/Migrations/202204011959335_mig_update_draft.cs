namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_update_draft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drafts", "MessageSubject", c => c.String(maxLength: 100));
            AddColumn("dbo.Drafts", "MessageContent", c => c.String(maxLength: 1000));
            DropColumn("dbo.Drafts", "DraftSubject");
            DropColumn("dbo.Drafts", "DraftContent");
        }

        public override void Down()
        {
            AddColumn("dbo.Drafts", "DraftContent", c => c.String(maxLength: 1000));
            AddColumn("dbo.Drafts", "DraftSubject", c => c.String(maxLength: 100));
            DropColumn("dbo.Drafts", "MessageContent");
            DropColumn("dbo.Drafts", "MessageSubject");
        }
    }
}
