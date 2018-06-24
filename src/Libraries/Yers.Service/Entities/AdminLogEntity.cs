namespace Yers.Service.Entities
{
    /// <summary>
    /// 管理员日志
    /// </summary>
    public class AdminLogEntity : BaseEntity
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        public long AdminUserId { get; set; }

        /// <summary>
        /// 管理员信息
        /// </summary>
        public virtual AdminUserEntity AdminUser { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Message { get; set; }
    }
}