namespace Yers.DTO.VIdeoDetail
{
    /// <summary>
    /// 视频详情
    /// </summary>
    public class VideoDetailListDto:BaseDto
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public long VideoId { get; set; }

        /// <summary>
        /// 课程标题
        /// </summary>
        public string VideoDetailName { get; set; }
        /// <summary>
        /// 课程摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 课程地址
        /// </summary>
        public string VideoLink { get; set; }

        /// <summary>
        /// 课程内容
        /// </summary>
        public string Content { get; set; }
    }
}