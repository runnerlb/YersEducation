namespace Yers.Service.Entities
{
    /// <summary>
    /// 书籍资料信息
    /// </summary>
    public class BookEntity : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string FacePicture { get; set; }

        /// <summary>
        /// 定价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 卖价
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int QuantityStock { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int QuantitySales { get; set; }

        /// <summary>
        /// 快递费用
        /// </summary>
        public decimal DeliveryCost { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string MoreDetail { get; set; }
    }
}