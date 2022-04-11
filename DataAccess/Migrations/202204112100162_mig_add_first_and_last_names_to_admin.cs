namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_add_first_and_last_names_to_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminFirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminLastName", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminLastName");
            DropColumn("dbo.Admins", "AdminFirstName");
        }
    }
}
