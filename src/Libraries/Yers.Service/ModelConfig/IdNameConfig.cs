using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class IdNameConfig : EntityTypeConfiguration<IdNameEntity>
    {
        public IdNameConfig()
        {
            ToTable("T_IdNames");

            Property(p => p.Name).IsRequired().HasMaxLength(1024);
            Property(p => p.TypeName).IsRequired().HasMaxLength(1024);
            Property(p => p.ImageSrc).HasMaxLength(1024);
            Property(p => p.Remark).HasMaxLength(1024);
        }
    }
}