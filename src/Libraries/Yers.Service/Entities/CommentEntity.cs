namespace Yers.Service.Entities
{
    /// <summary>
    /// 评论信息
    /// </summary>
    public class CommentEntity : BaseEntity
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
        /// 评论人Id
        /// </summary>
        public long FromUserId { get; set; }

        /// <summary>
        /// 评论人信息
        /// </summary>
        public virtual UserEntity FromUser { get; set; }

        /// <summary>
        /// 评论信息
        /// </summary>
        public string Content { get; set; }
    }
}