namespace Yers.DTO.VIdeoDetail
{
    /// <summary>
    /// 视频详情
    /// </summary>
    public class VideoDetailAddDto:BaseDto
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public long VideoId { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string VideoDetailName { get; set; }
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