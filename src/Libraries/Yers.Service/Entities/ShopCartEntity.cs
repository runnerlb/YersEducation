using System;

namespace Yers.Service.Entities
{
    /// <summary>
    /// 购物车信息
    /// </summary>
    public class ShopCartEntity : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual UserEntity User { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int BookCount { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public long BookId { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual BookEntity Book { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 加入购物车时的金额
        /// </summary>
        public decimal Money { get; set; }
    }
}