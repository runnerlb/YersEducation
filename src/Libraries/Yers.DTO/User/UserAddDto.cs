using System;

namespace Yers.DTO.User
{
    public class UserAddDto : BaseDto
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
        /// 微信地址
        /// </summary>
        public string WxAddress { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDataTime { get; set; }
    }
}