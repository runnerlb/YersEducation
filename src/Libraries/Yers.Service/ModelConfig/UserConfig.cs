using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class UserConfig : EntityTypeConfiguration<UserEntity>
    {
        public UserConfig()
        {
            ToTable("T_Users");

            Property(m => m.UserName).IsRequired().HasMaxLength(50);
            Property(m => m.HeadPortraitSrc).IsRequired().HasMaxLength(100);
            Property(m => m.AccountNumber).IsRequired().HasMaxLength(50).IsUnicode(false);
            Property(m => m.RealName).IsRequired().HasMaxLength(20);
            Property(m => m.PhoneNumber).IsRequired().HasMaxLength(20).IsUnicode(false);
            Property(m => m.PaymentPassword).IsRequired().HasMaxLength(50);
        }
    }
}