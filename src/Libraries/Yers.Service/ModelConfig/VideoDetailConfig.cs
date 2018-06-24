using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class VideoDetailConfig : EntityTypeConfiguration<VideoDetailEntity>
    {
        public VideoDetailConfig()
        {
            ToTable("T_VideoDetails");

            HasRequired(m => m.Video).WithMany().HasForeignKey(m => m.VideoId).WillCascadeOnDelete(false);

            Property(m => m.Summary).IsRequired().HasMaxLength(500);
            Property(m => m.VideoLink).IsRequired().HasMaxLength(200);
            Property(m => m.Content).IsRequired();
        }
    }
}