using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class SettingConfig : EntityTypeConfiguration<SettingEntity>
    {
        public SettingConfig()
        {
            ToTable("T_Settings");

            Property(p => p.Name).IsRequired().HasMaxLength(1024);
            Property(p => p.Value).IsRequired();
        }
    }
}