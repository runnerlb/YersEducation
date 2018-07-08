namespace Yers.DTO
{
    public class AdminLogDto : BaseDto
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        public long AdminUserId { get; set; }

        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string AdminUserName { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 操作Ip
        /// </summary>
        public string OperIp { get; set; }
    }
}