namespace Yers.Service.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AdminLogs",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    AdminUserId = c.Long(nullable: false),
                    Message = c.String(nullable: false, maxLength: 500),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_AdminUsers", t => t.AdminUserId)
                .Index(t => t.AdminUserId);

            CreateTable(
                "dbo.T_AdminUsers",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    LoginName = c.String(nullable: false, maxLength: 50),
                    UserName = c.String(nullable: false, maxLength: 50),
                    PasswordHash = c.String(nullable: false, maxLength: 100, unicode: false),
                    PasswordSalt = c.String(nullable: false, maxLength: 20, unicode: false),
                    PhoneNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                    Email = c.String(nullable: false, maxLength: 50, unicode: false),
                    LoginErrorTimes = c.Int(nullable: false),
                    LastLoginErrorDateTime = c.DateTime(),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Roles",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Permissions",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Description = c.String(maxLength: 1024),
                    Name = c.String(nullable: false, maxLength: 50),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Books",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    Synopsis = c.String(),
                    FacePicture = c.String(nullable: false, maxLength: 200),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    QuantityStock = c.Int(nullable: false),
                    QuantitySales = c.Int(nullable: false),
                    DeliveryCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ShipAddress = c.String(nullable: false, maxLength: 100),
                    MoreDetail = c.String(),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Comments",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    VideoId = c.Long(),
                    BookId = c.Long(),
                    FromUserId = c.Long(nullable: false),
                    Content = c.String(nullable: false, maxLength: 1000),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Books", t => t.BookId)
                .ForeignKey("dbo.T_Users", t => t.FromUserId)
                .ForeignKey("dbo.T_Videos", t => t.VideoId)
                .Index(t => t.VideoId)
                .Index(t => t.BookId)
                .Index(t => t.FromUserId);

            CreateTable(
                "dbo.T_Users",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 50),
                    HeadPortraitSrc = c.String(nullable: false, maxLength: 100),
                    AccountNumber = c.String(nullable: false, maxLength: 50, unicode: false),
                    RealName = c.String(nullable: false, maxLength: 20),
                    PhoneNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                    UserLevel = c.Int(nullable: false),
                    Sex = c.Boolean(nullable: false),
                    AddressId = c.Int(nullable: false),
                    RegisterDataTime = c.DateTime(nullable: false),
                    LastLoginDateTime = c.DateTime(),
                    PaymentPassword = c.String(nullable: false, maxLength: 50),
                    ReferrerId = c.Int(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Videos",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    CoverPicture = c.String(nullable: false, maxLength: 200),
                    Title = c.String(nullable: false, maxLength: 100),
                    LecturerName = c.String(nullable: false, maxLength: 50),
                    LecturerHead = c.String(nullable: false, maxLength: 200),
                    LecturerPosition = c.String(nullable: false, maxLength: 50),
                    OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PreferentialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    VideoContent = c.String(nullable: false),
                    OnlineTime = c.DateTime(nullable: false),
                    AdminUserId = c.Long(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_AdminUsers", t => t.AdminUserId)
                .Index(t => t.AdminUserId);

            CreateTable(
                "dbo.T_IdNames",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TypeName = c.String(nullable: false, maxLength: 1024),
                    Name = c.String(nullable: false, maxLength: 1024),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Likes",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    VideoId = c.Long(),
                    BookId = c.Long(),
                    UserId = c.Long(nullable: false),
                    Status = c.Boolean(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Books", t => t.BookId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .ForeignKey("dbo.T_Videos", t => t.VideoId)
                .Index(t => t.VideoId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.T_OrderDetails",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Orders",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_Replys",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    VideoId = c.Long(),
                    BookId = c.Long(),
                    CommentId = c.Long(nullable: false),
                    Content = c.String(nullable: false, maxLength: 1000),
                    FromUserId = c.Long(nullable: false),
                    ToUserId = c.Long(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Books", t => t.BookId)
                .ForeignKey("dbo.T_Comments", t => t.CommentId)
                .ForeignKey("dbo.T_Users", t => t.FromUserId)
                .ForeignKey("dbo.T_Users", t => t.ToUserId)
                .ForeignKey("dbo.T_Videos", t => t.VideoId)
                .Index(t => t.VideoId)
                .Index(t => t.BookId)
                .Index(t => t.CommentId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);

            CreateTable(
                "dbo.T_Settings",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 1024),
                    Value = c.String(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.T_ShopCarts",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    UserId = c.Long(nullable: false),
                    BookCount = c.Int(nullable: false),
                    BookId = c.Long(nullable: false),
                    UpdateDateTime = c.DateTime(),
                    Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Books", t => t.BookId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BookId);

            CreateTable(
                "dbo.T_VideoDetails",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    VideoId = c.Long(nullable: false),
                    Summary = c.String(nullable: false, maxLength: 500),
                    VideoLink = c.String(nullable: false, maxLength: 200),
                    Content = c.String(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Videos", t => t.VideoId)
                .Index(t => t.VideoId);

            CreateTable(
                "dbo.T_RolePermissions",
                c => new
                {
                    RoleId = c.Long(nullable: false),
                    PermissionId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId })
                .ForeignKey("dbo.T_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.T_Permissions", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);

            CreateTable(
                "dbo.T_AdminUserRoles",
                c => new
                {
                    AdminUserId = c.Long(nullable: false),
                    RoleId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.AdminUserId, t.RoleId })
                .ForeignKey("dbo.T_AdminUsers", t => t.AdminUserId, cascadeDelete: true)
                .ForeignKey("dbo.T_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.RoleId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.T_VideoDetails", "VideoId", "dbo.T_Videos");
            DropForeignKey("dbo.T_ShopCarts", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_ShopCarts", "BookId", "dbo.T_Books");
            DropForeignKey("dbo.T_Replys", "VideoId", "dbo.T_Videos");
            DropForeignKey("dbo.T_Replys", "ToUserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Replys", "FromUserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Replys", "CommentId", "dbo.T_Comments");
            DropForeignKey("dbo.T_Replys", "BookId", "dbo.T_Books");
            DropForeignKey("dbo.T_Likes", "VideoId", "dbo.T_Videos");
            DropForeignKey("dbo.T_Likes", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Likes", "BookId", "dbo.T_Books");
            DropForeignKey("dbo.T_Comments", "VideoId", "dbo.T_Videos");
            DropForeignKey("dbo.T_Videos", "AdminUserId", "dbo.T_AdminUsers");
            DropForeignKey("dbo.T_Comments", "FromUserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Comments", "BookId", "dbo.T_Books");
            DropForeignKey("dbo.T_AdminLogs", "AdminUserId", "dbo.T_AdminUsers");
            DropForeignKey("dbo.T_AdminUserRoles", "RoleId", "dbo.T_Roles");
            DropForeignKey("dbo.T_AdminUserRoles", "AdminUserId", "dbo.T_AdminUsers");
            DropForeignKey("dbo.T_RolePermissions", "PermissionId", "dbo.T_Permissions");
            DropForeignKey("dbo.T_RolePermissions", "RoleId", "dbo.T_Roles");
            DropIndex("dbo.T_AdminUserRoles", new[] { "RoleId" });
            DropIndex("dbo.T_AdminUserRoles", new[] { "AdminUserId" });
            DropIndex("dbo.T_RolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.T_RolePermissions", new[] { "RoleId" });
            DropIndex("dbo.T_VideoDetails", new[] { "VideoId" });
            DropIndex("dbo.T_ShopCarts", new[] { "BookId" });
            DropIndex("dbo.T_ShopCarts", new[] { "UserId" });
            DropIndex("dbo.T_Replys", new[] { "ToUserId" });
            DropIndex("dbo.T_Replys", new[] { "FromUserId" });
            DropIndex("dbo.T_Replys", new[] { "CommentId" });
            DropIndex("dbo.T_Replys", new[] { "BookId" });
            DropIndex("dbo.T_Replys", new[] { "VideoId" });
            DropIndex("dbo.T_Likes", new[] { "UserId" });
            DropIndex("dbo.T_Likes", new[] { "BookId" });
            DropIndex("dbo.T_Likes", new[] { "VideoId" });
            DropIndex("dbo.T_Videos", new[] { "AdminUserId" });
            DropIndex("dbo.T_Comments", new[] { "FromUserId" });
            DropIndex("dbo.T_Comments", new[] { "BookId" });
            DropIndex("dbo.T_Comments", new[] { "VideoId" });
            DropIndex("dbo.T_AdminLogs", new[] { "AdminUserId" });
            DropTable("dbo.T_AdminUserRoles");
            DropTable("dbo.T_RolePermissions");
            DropTable("dbo.T_VideoDetails");
            DropTable("dbo.T_ShopCarts");
            DropTable("dbo.T_Settings");
            DropTable("dbo.T_Replys");
            DropTable("dbo.T_Orders");
            DropTable("dbo.T_OrderDetails");
            DropTable("dbo.T_Likes");
            DropTable("dbo.T_IdNames");
            DropTable("dbo.T_Videos");
            DropTable("dbo.T_Users");
            DropTable("dbo.T_Comments");
            DropTable("dbo.T_Books");
            DropTable("dbo.T_Permissions");
            DropTable("dbo.T_Roles");
            DropTable("dbo.T_AdminUsers");
            DropTable("dbo.T_AdminLogs");
        }
    }
}