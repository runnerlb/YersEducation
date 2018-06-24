namespace Yers.Service.Entities
{
    /// <summary>
    /// 点赞信息
    /// </summary>
    public class LikeEntity : BaseEntity
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public long? VideoId { get; set; }

        /// <summary>
        /// 视频信息
        /// </summary>
        public virtual VideoEntity Video { get; set; }

        /// <summary>
        /// 书籍Id
        /// </summary>
        public long? BookId { get; set; }

        /// <summary>
        /// 书籍信息
        /// </summary>
        public virtual BookEntity Book { get; set; }

        /// <summary>
        /// 点赞人Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 点赞人信息
        /// </summary>
        public virtual UserEntity User { get; set; }

        /// <summary>
        /// 点赞状态 true 有效赞   false 取消赞
        /// </summary>
        public bool Status { get; set; }
    }
}