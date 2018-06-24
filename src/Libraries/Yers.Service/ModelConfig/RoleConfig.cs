using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class RoleConfig : EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfig()
        {
            ToTable("T_Roles");

            HasMany(r => r.Permissions).WithMany(p => p.Roles).Map(m => m.ToTable("T_RolePermissions")
                .MapLeftKey("RoleId").MapRightKey("PermissionId"));

            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}