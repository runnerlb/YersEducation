using System.Data.Entity;
using System.Reflection;
using log4net;
using Yers.Service.Entities;

namespace Yers.Service
{
    internal class YersDbContext : DbContext
    {
        private static ILog log = LogManager.GetLogger(typeof(YersDbContext));

        public YersDbContext() : base("name=YersConnection")
        {
            this.Database.Log = (sql) =>
            {
                log.DebugFormat("EF执行SQL：{0}", sql);
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AdminLogEntity> AdminLogs { get; set; }
        public DbSet<AdminUserEntity> AdminUsers { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<IdNameEntity> IdNames { get; set; }
        public DbSet<LikeEntity> Likes { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<ReplyEntity> Replys { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
        public DbSet<ShopCartEntity> ShopCarts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VideoDetailEntity> VideoDetails { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
    }
}