namespace Yers.Service.Entities
{
    /// <summary>
    /// 视频详情
    /// </summary>
    public class VideoDetailEntity : BaseEntity
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public long VideoId { get; set; }

        /// <summary>
        /// 视频信息
        /// </summary>
        public virtual VideoEntity Video { get; set; }

        /// <summary>
        /// 视频摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoLink { get; set; }

        /// <summary>
        /// 视频内容
        /// </summary>
        public string Content { get; set; }
    }
}