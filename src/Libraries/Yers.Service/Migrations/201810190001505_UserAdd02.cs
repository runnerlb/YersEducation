namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdd02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Users", "HeadPortraitSrc", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.T_Users", "UserLevel", c => c.Int());
            AlterColumn("dbo.T_Users", "AddressId", c => c.Int());
            AlterColumn("dbo.T_Users", "ReferrerId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Users", "ReferrerId", c => c.Int(nullable: false));
            AlterColumn("dbo.T_Users", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.T_Users", "UserLevel", c => c.Int(nullable: false));
            AlterColumn("dbo.T_Users", "HeadPortraitSrc", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
