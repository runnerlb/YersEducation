namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoAddSummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Videos", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Videos", "Summary");
        }
    }
}
