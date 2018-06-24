using System;

namespace Yers.Service.Entities
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string HeadPortraitSrc { get; set; }

        /// <summary>
        /// 微信账号
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public int UserLevel { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 地区地址
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDataTime { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? LastLoginDateTime { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PaymentPassword { get; set; }

        /// <summary>
        /// 推荐人Id
        /// </summary>
        public int ReferrerId { get; set; }
    }
}