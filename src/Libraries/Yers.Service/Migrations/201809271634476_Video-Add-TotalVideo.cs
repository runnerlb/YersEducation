namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoAddTotalVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Videos", "TotalVideos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Videos", "TotalVideos");
        }
    }
}
