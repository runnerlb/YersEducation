using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class AdminLogConfig : EntityTypeConfiguration<AdminLogEntity>
    {
        public AdminLogConfig()
        {
            ToTable("T_AdminLogs");

            HasRequired(m => m.AdminUser).WithMany().HasForeignKey(e => e.AdminUserId).WillCascadeOnDelete(false);

            Property(m => m.Message).HasMaxLength(500).IsRequired();
        }
    }
}