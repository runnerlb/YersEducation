using System;

namespace Yers.Service.Entities
{
    /// <summary>
    /// 视频信息
    /// </summary>
    public class VideoEntity : BaseEntity
    {
        /// <summary>
        /// 视频封面图片
        /// </summary>
        public string CoverPicture { get; set; }

        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 讲师姓名
        /// </summary>
        public string LecturerName { get; set; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string LecturerHead { get; set; }

        /// <summary>
        /// 讲师职位
        /// </summary>
        public string LecturerPosition { get; set; }

        /// <summary>
        /// 原始价格
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// 优惠价格
        /// </summary>
        public decimal PreferentialPrice { get; set; }

        /// <summary>
        /// 视频内容
        /// </summary>
        public string VideoContent { get; set; }

        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime OnlineTime { get; set; }

        /// <summary>
        /// 上传人
        /// </summary>
        public virtual AdminUserEntity AdminUser { get; set; }

        /// <summary>
        /// 上传人Id
        /// </summary>
        public long AdminUserId { get; set; }
    }
}