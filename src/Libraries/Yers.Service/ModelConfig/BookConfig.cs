using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class BookConfig : EntityTypeConfiguration<BookEntity>
    {
        public BookConfig()
        {
            ToTable("T_Books");

            Property(m => m.Name).HasMaxLength(100).IsRequired();
            Property(m => m.FacePicture).HasMaxLength(200).IsRequired();
            Property(m => m.ShipAddress).HasMaxLength(100).IsRequired();
        }
    }
}