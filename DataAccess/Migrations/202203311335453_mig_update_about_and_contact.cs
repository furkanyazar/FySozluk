namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mig_update_about_and_contact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImageUrl1", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "AboutImageUrl2", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contacts", "ContactMessage", c => c.String(maxLength: 1000));
        }

        public override void Down()
        {
            AlterColumn("dbo.Contacts", "ContactMessage", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImageUrl2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImageUrl1", c => c.String(maxLength: 100));
        }
    }
}
