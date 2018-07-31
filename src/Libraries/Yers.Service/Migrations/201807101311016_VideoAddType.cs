namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoAddType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Videos", "CourseTypeId", c => c.Long(nullable: false));
            AddColumn("dbo.T_Videos", "VideoTypeId", c => c.Long(nullable: false));
            CreateIndex("dbo.T_Videos", "CourseTypeId");
            CreateIndex("dbo.T_Videos", "VideoTypeId");
            AddForeignKey("dbo.T_Videos", "CourseTypeId", "dbo.T_IdNames", "Id");
            AddForeignKey("dbo.T_Videos", "VideoTypeId", "dbo.T_IdNames", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Videos", "VideoTypeId", "dbo.T_IdNames");
            DropForeignKey("dbo.T_Videos", "CourseTypeId", "dbo.T_IdNames");
            DropIndex("dbo.T_Videos", new[] { "VideoTypeId" });
            DropIndex("dbo.T_Videos", new[] { "CourseTypeId" });
            DropColumn("dbo.T_Videos", "VideoTypeId");
            DropColumn("dbo.T_Videos", "CourseTypeId");
        }
    }
}
