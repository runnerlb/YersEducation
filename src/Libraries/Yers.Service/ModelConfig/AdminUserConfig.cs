using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class AdminUserConfig : EntityTypeConfiguration<AdminUserEntity>
    {
        public AdminUserConfig()
        {
            ToTable("T_AdminUsers");

            HasMany(r => r.Role).WithMany(a => a.AdminUsers).Map(m => m.ToTable("T_AdminUserRoles")
                .MapLeftKey("AdminUserId").MapRightKey("RoleId"));

            Property(m => m.LoginName).HasMaxLength(50).IsRequired();
            Property(m => m.UserName).HasMaxLength(50).IsRequired();
            Property(m => m.Email).HasMaxLength(50).IsRequired().IsUnicode(false);
            Property(m => m.PhoneNumber).HasMaxLength(20).IsRequired().IsUnicode(false);
            Property(e => e.PasswordHash).HasMaxLength(100).IsRequired().IsUnicode(false);
        }
    }
}