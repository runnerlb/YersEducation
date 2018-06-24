using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class ShopCartConfig : EntityTypeConfiguration<ShopCartEntity>
    {
        public ShopCartConfig()
        {
            ToTable("T_ShopCarts");

            HasRequired(m => m.User).WithMany().HasForeignKey(m => m.UserId).WillCascadeOnDelete(false);
            HasRequired(m => m.Book).WithMany().HasForeignKey(m => m.BookId).WillCascadeOnDelete(false);
        }
    }
}