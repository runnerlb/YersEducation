namespace Yers.Service.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteAdminUserPasswordSalt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_AdminUsers", "PasswordSalt");
        }

        public override void Down()
        {
            AddColumn("dbo.T_AdminUsers", "PasswordSalt", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}