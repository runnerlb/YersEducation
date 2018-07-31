namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoDetailAddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_VideoDetails", "VideoDetailName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_VideoDetails", "VideoDetailName");
        }
    }
}
