using System.Data.Entity.ModelConfiguration;
using Yers.Service.Entities;

namespace Yers.Service.ModelConfig
{
    public class OrderDetailConfig : EntityTypeConfiguration<OrderDetailEntity>
    {
        public OrderDetailConfig()
        {
            ToTable("T_OrderDetails");
        }
    }
}