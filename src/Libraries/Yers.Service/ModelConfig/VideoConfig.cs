using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class VideoConfig : EntityTypeConfiguration<VideoEntity>
    {
        public VideoConfig()
        {
            ToTable("T_Videos");

            HasRequired(m => m.AdminUser).WithMany().HasForeignKey(m => m.AdminUserId).WillCascadeOnDelete(false);

            Property(m => m.CoverPicture).IsRequired().HasMaxLength(200);
            Property(m => m.Title).IsRequired().HasMaxLength(100);
            Property(m => m.LecturerName).IsRequired().HasMaxLength(50);
            Property(m => m.LecturerHead).IsRequired().HasMaxLength(200);
            Property(m => m.LecturerPosition).IsRequired().HasMaxLength(50);
            Property(m => m.VideoContent).IsRequired();
        }
    }
}