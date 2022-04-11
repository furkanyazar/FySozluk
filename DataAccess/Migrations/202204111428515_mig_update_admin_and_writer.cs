namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_update_admin_and_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 500));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 500));
            DropColumn("dbo.Admins", "AdminUserName");
        }

        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 250));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminEmail");
        }
    }
}
