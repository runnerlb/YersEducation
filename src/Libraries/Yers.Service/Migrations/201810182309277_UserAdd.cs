namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Users", "WxAddress", c => c.String());
            AlterColumn("dbo.T_Users", "RealName", c => c.String(maxLength: 20));
            AlterColumn("dbo.T_Users", "PhoneNumber", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.T_Users", "PaymentPassword", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Users", "PaymentPassword", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.T_Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.T_Users", "RealName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.T_Users", "WxAddress");
        }
    }
}
