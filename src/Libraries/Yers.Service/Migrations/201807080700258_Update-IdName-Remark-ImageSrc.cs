namespace Yers.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdNameRemarkImageSrc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_IdNames", "ImageSrc", c => c.String(maxLength: 1024));
            AddColumn("dbo.T_IdNames", "Remark", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_IdNames", "Remark");
            DropColumn("dbo.T_IdNames", "ImageSrc");
        }
    }
}
