using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class PermissionConfig : EntityTypeConfiguration<PermissionEntity>
    {
        public PermissionConfig()
        {
            ToTable("T_Permissions");

            Property(p => p.Description).IsOptional().HasMaxLength(1024);
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}