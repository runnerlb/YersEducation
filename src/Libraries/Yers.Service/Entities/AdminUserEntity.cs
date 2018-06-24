using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Yers.Service.Entities
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    public class AdminUserEntity : BaseEntity
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录错误次数
        /// </summary>
        public int LoginErrorTimes { get; set; }

        /// <summary>
        /// 最后一次登录错误时间
        /// </summary>
        public DateTime? LastLoginErrorDateTime { get; set; }

        /// <summary>
        /// 用户角色信息
        /// </summary>
        public virtual ICollection<RoleEntity> Role { get; set; } = new List<RoleEntity>();
    }
}