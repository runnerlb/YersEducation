namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminLogAddOperIp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_AdminLogs", "OperIp", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_AdminLogs", "OperIp");
        }
    }
}
