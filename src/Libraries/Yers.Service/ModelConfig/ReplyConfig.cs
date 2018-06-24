using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class ReplyConfig : EntityTypeConfiguration<ReplyEntity>
    {
        public ReplyConfig()
        {
            ToTable("T_Replys");

            HasOptional(m => m.Video).WithMany().HasForeignKey(m => m.VideoId).WillCascadeOnDelete(false);
            HasOptional(m => m.Book).WithMany().HasForeignKey(m => m.BookId).WillCascadeOnDelete(false);
            HasRequired(m => m.Comment).WithMany().HasForeignKey(m => m.CommentId).WillCascadeOnDelete(false);
            HasRequired(m => m.FromUser).WithMany().HasForeignKey(m => m.FromUserId).WillCascadeOnDelete(false);
            HasRequired(m => m.ToUser).WithMany().HasForeignKey(m => m.ToUserId).WillCascadeOnDelete(false);

            Property(m => m.Content).IsRequired().HasMaxLength(1000);
        }
    }
}