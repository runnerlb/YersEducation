using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class CommentConfig : EntityTypeConfiguration<CommentEntity>
    {
        public CommentConfig()
        {
            ToTable("T_Comments");

            HasOptional(m => m.Video).WithMany().HasForeignKey(m => m.VideoId).WillCascadeOnDelete(false);
            HasOptional(m => m.Book).WithMany().HasForeignKey(m => m.BookId).WillCascadeOnDelete(false);
            HasRequired(m => m.FromUser).WithMany().HasForeignKey(m => m.FromUserId).WillCascadeOnDelete(false);

            Property(m => m.Content).IsRequired().HasMaxLength(1000);
        }
    }
}