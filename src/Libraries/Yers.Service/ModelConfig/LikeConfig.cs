using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class LikeConfig : EntityTypeConfiguration<LikeEntity>
    {
        public LikeConfig()
        {
            ToTable("T_Likes");

            HasOptional(m => m.Video).WithMany().HasForeignKey(m => m.VideoId).WillCascadeOnDelete(false);
            HasOptional(m => m.Book).WithMany().HasForeignKey(m => m.BookId).WillCascadeOnDelete(false);
            HasRequired(m => m.User).WithMany().HasForeignKey(m => m.UserId).WillCascadeOnDelete(false);
        }
    }
}